﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ProjectRegistration.Models;

namespace ProjectRegistration.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IDENTITYUSERContext _context;

        public ClassesController(IDENTITYUSERContext context)
        {
            _context = context;
        }

        // GET: Classes
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index()
        {
            var IDENTITYUSERContext = _context.Classes.Include(x => x.Course).Where(x => x.Deleted == false).OrderBy(x => x.Id);
            return View(await IDENTITYUSERContext.ToListAsync());
        }

        // GET: Classes/Details/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Where(x => x.Deleted == false)
                .Include(x => x.Course)
                .Include(x => x.ClassDetails)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }
            var list = @class.ClassDetails.Where(x => x.Deleted == false).ToList();
            @class.ClassDetails = list;
            return View(@class);
        }

        // GET: Classes/Create
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            ViewData["Course"] = new SelectList(_context.Courses, "Id", "CourseName");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("Id,CourseId,ClassId,Semester,Cyear,RegOpen,RegStart,RegEnd,CreatedDateTime,Deleted,DeletedDateTime")] Class @class)
        {
            if (ModelState.IsValid)
            {
                @class.CreatedDateTime = DateTime.Now;
                @class.RegOpen = "Đóng đăng ký";
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Course"] = new SelectList(_context.Courses, "CourseName", "CourseName", @class.CourseId);
            return View(@class);
        }

        // GET: Classes/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes.Include(x=>x.Course).Where(x=> x.Id == id).FirstOrDefaultAsync();
            if (@class == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", @class.CourseId);
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,ClassId,Semester,Cyear,RegOpen,RegStart,RegEnd,CreatedDateTime,Deleted,DeletedDateTime")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Debug.WriteLine(@class.RegOpen + "\n" + @class.RegStart.ToString() + "\n" + @class.RegEnd.ToString());
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", @class.CourseId);
            return View(@class);
        }

        // GET: Classes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Classes == null)
        //    {
        //        return NotFound();
        //    }

        //    var @class = await _context.Classes
        //        .Include(x => x.Course)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (@class == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(@class);
        //}

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'ProjectRegistrationManagementContext.Classes'  is null.");
            }
            var @class = await _context.Classes.FindAsync(id);
            if (@class != null)
            {
                @class.Deleted = true;
                @class.DeletedDateTime = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return (_context.Classes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost, ActionName("AddUserFromFileExcel")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> AddUserFromFileExcel(int Id, IFormFile fileSelect)
        {
            var fileextension = Path.GetExtension(fileSelect.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filename);
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                fileSelect.CopyTo(fs);
            }

            using (var stream = System.IO.File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    reader.Read();
                    var @class = _context.Classes.Where(x => (x.Deleted == false && x.Id == Id)).FirstOrDefault();

                    List<ClassDetail> cd = new List<ClassDetail>();

                    while (reader.Read()) //Each row of the file
                    {

                        var user = _context.Users.Where(x => (x.UserId == reader.GetValue(1).ToString() && x.Deleted == false)).FirstOrDefault();
                        if (user == null) continue;
                        if (_context.ClassDetails.Where(x => x.ClassId == Id && x.UserId == user.Id).FirstOrDefault() != null) continue;

                        ClassDetail classDetail = new ClassDetail();
                        classDetail.ClassId = Id;
                        classDetail.UserId = user.Id;
                        classDetail.Class = @class;
                        classDetail.User = user;
                        classDetail.CreatedDateTime = DateTime.Now;
                        List<ClassDetail> userCd = new List<ClassDetail>();
                        userCd = user.ClassDetails.ToList();
                        userCd.Add(classDetail);
                        user.ClassDetails = userCd;
                        cd.Add(classDetail);                       
                        _context.ClassDetails.Add(classDetail);
                    }
                    @class.ClassDetails = cd;

                }
            }

            System.IO.File.Delete(filepath);

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = Id} );
        }

        [HttpPost, ActionName("GetUsersInClass")]
        public IActionResult GetUsersInClass(int id)
        {
            return RedirectToAction("GetUsersInClass", "ClassDetailsController", id);
        }

        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'ProjectRegistrationManagementContext.Classes'  is null.");
            }            
            string[] ids = id.Split('-');
            var @classDetails = _context.ClassDetails.Where(x => x.UserId == ids[0] && x.ClassId == int.Parse(ids[1])).FirstOrDefault();
            if (@classDetails != null)
            {
                @classDetails.Deleted = true;
                @classDetails.DeletedDateTime = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = int.Parse(ids[1]) });
        }

        [HttpPost, ActionName("AddUser")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> AddUser(string id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'ProjectRegistrationManagementContext.Classes'  is null.");
            }
            string[] ids = id.Split('-');

            var user = _context.Users.Where(x => (x.UserId == ids[0] && x.Deleted == false)).FirstOrDefault();            
            var @class = _context.Classes.Where(x => (x.Id == int.Parse(ids[1]) && x.Deleted == false)).Include(x => x.ClassDetails).FirstOrDefault();
            if (!@class.ClassDetails.Any(x => x.UserId == user.Id))
            {
                ClassDetail classDetail = new ClassDetail();
                classDetail.ClassId = @class.Id;
                classDetail.UserId = user.Id;
                classDetail.Class = @class;
                classDetail.User = user;
                classDetail.CreatedDateTime = DateTime.Now;
                _context.ClassDetails.Add(classDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = int.Parse(ids[1]) });
        }

        [ActionName("ViewProjectList")]
        public async Task<IActionResult> ViewProjectList(int id)
        {
            var @class = _context.Classes.Where(x => x.Deleted == false && x.Id == id)
                .Include(x => x.ProjectClasses).ThenInclude(x => x.GuidingLecturer)
                .Include(x => x.ProjectClasses).ThenInclude(x => x.GradingLecturer)
                .FirstOrDefault();
            var projectList = new List<Project>();
            projectList = @class.ProjectClasses.Where(x => x.Deleted == false).ToList();
            ViewData["id"] = id;
            return View(projectList);
        }

        // GET: Projects/Create
        public IActionResult CreateProject(int id)
        {
            ViewData["id"] = id;
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["ClassId2"] = new SelectList(_context.Classes, "Id", "Id");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            ViewData["GradingLecturerId"] = new SelectList(_context.Users.Where(x => x.UserTypeId == 10), "Id", "Fullname");
            ViewData["GuidingLecturerId"] = new SelectList(_context.Users.Where(x => x.UserTypeId == 10), "Id", "Fullname");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("CreateProject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject([Bind("Id,Pname,Info,DepartmentId,ClassId,ClassId2,GuidingLecturerId,GradingLecturerId,Pyear,Semester,CreatedDateTime,Deleted,DeletedDateTime")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.Id = 0;
                project.CreatedDateTime = DateTime.Now;
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewProjectList", new { id = project.ClassId });
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", project.ClassId);
            ViewData["ClassId2"] = new SelectList(_context.Classes, "Id", "Id", project.ClassId2);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", project.DepartmentId);
            ViewData["GradingLecturerId"] = new SelectList(_context.Users, "Id", "Id", project.GradingLecturerId);
            ViewData["GuidingLecturerId"] = new SelectList(_context.Users, "Id", "Id", project.GuidingLecturerId);
            return RedirectToAction("CreateProject", new { id = project.ClassId });
        }

        [HttpPost, ActionName("AddProjectFromFileExcel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProjectFromFileExcel(IFormCollection form, IFormFile fileSelect)
        {
            int classId = int.Parse(form["classId"]);
            var fileextension = Path.GetExtension(fileSelect.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filename);
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                fileSelect.CopyTo(fs);
            }

            using (var stream = System.IO.File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    reader.Read();
                    reader.Read();
                    reader.Read();
                    var @class = _context.Classes.Where(x => (x.Deleted == false && x.Id == classId)).FirstOrDefault();

                    var cd = new List<Project>();
                    foreach (var x in @class.ProjectClasses)
                    {
                        cd.Add(x);
                    }

                    while (reader.Read()) //Each row of the file
                    {
                        if (reader.GetValue(1) == null) continue;
                        var existProject = _context.Projects
                            .Where(x => x.Deleted == false && x.Pname == reader.GetValue(1).ToString() && x.ClassId == classId).FirstOrDefault();
                        if (existProject != null) continue;
                        var project = new Project();
                        project.Pname = reader.GetValue(1).ToString();
                        var user = _context.Users.Where(x => (x.Fullname == reader.GetValue(3).ToString() && x.Deleted == false)).FirstOrDefault();
                        if (user == null) continue;
                        project.GuidingLecturer = user;
                        project.GuidingLecturerId = user.Id;
                        project.Info = reader.GetValue(2) == null? "" : reader.GetValue(2).ToString();
                        project.CreatedDateTime = DateTime.Now;
                        project.ClassId = classId;
                        cd.Add(project);
                        _context.Projects.Add(project);
                    }

                    @class.ProjectClasses = cd;
                }
            }

            System.IO.File.Delete(filepath);

            await _context.SaveChangesAsync();
            return RedirectToAction("ViewProjectList", new { id = classId });
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("DeleteProject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'ProjectRegistrationManagementContext.Projects'  is null.");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                project.Deleted = true;
                project.DeletedDateTime = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ViewProjectList", new { id = project.ClassId });
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> EditProject(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["id"] = project.ClassId;
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", project.ClassId);
            ViewData["ClassId2"] = new SelectList(_context.Classes, "Id", "Id", project.ClassId2);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", project.DepartmentId);
            ViewData["GradingLecturerId"] = new SelectList(_context.Users.Where(x => x.Deleted == false && x.UserTypeId == 10), "Id", "Fullname", project.GradingLecturerId);
            ViewData["GuidingLecturerId"] = new SelectList(_context.Users.Where(x => x.Deleted == false && x.UserTypeId == 10), "Id", "Fullname", project.GuidingLecturerId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("EditProject")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProject(int id, [Bind("Id,Pname,Info,DepartmentId,ClassId,ClassId2,GuidingLecturerId,GradingLecturerId,Pyear,Semester,CreatedDateTime,Deleted,DeletedDateTime")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Projects.Any(x => x.Id == project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ViewProjectList", new { id = project.ClassId });
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", project.ClassId);
            ViewData["ClassId2"] = new SelectList(_context.Classes, "Id", "Id", project.ClassId2);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", project.DepartmentId);
            ViewData["GradingLecturerId"] = new SelectList(_context.Users, "Id", "Id", project.GradingLecturerId);
            ViewData["GuidingLecturerId"] = new SelectList(_context.Users, "Id", "Id", project.GuidingLecturerId);
            return RedirectToAction("EditProject", new { id = project.Id });
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> ProjectDetails(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Where(p => p.Deleted == false)
                .Include(p => p.Class)
                .Include(p => p.ProjectMembers)
                .Include(p => p.GradingLecturer)
                .Include(p => p.GuidingLecturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: ProjectMembers/Create
        public IActionResult AddMemberToProject(int id)
        {
            ViewData["id"] = id;
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            ViewData["Project"] = project;
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Id");
            var classDetails = _context.ClassDetails.Where(x => x.ClassId == project.ClassId).Include(x => x.User).ToList();
            
            ViewData["StudentId1"] = new SelectList(classDetails, "UserId", "User.Fullname");
            ViewData["StudentId2"] = new SelectList(classDetails, "UserId", "User.Fullname");
            return View();
        }

        // POST: ProjectMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMemberToProject([Bind("ProjectId, GroupName")] ProjectMember projectMember, string StudentId1, string StudentId2)
        {
            ModelState.Remove("StudentId2");
            if (ModelState.IsValid)
            {
                var projectMember1 = new ProjectMember();
                projectMember1.CreatedDateTime = DateTime.Now;
                projectMember1.Project = _context.Projects.FirstOrDefault(x => x.Id == projectMember1.ProjectId);
                projectMember1.ProjectId = projectMember.ProjectId;
                projectMember1.Student = _context.Users.FirstOrDefault(x => x.Id == projectMember1.StudentId);
                projectMember1.StudentId = StudentId1;
                projectMember1.GroupName = projectMember.GroupName;
                _context.Add(projectMember1);
                if (StudentId2 == null)
                {
                    var projectMember2 = new ProjectMember();
                    projectMember2.CreatedDateTime = DateTime.Now;
                    projectMember2.Project = _context.Projects.FirstOrDefault(x => x.Id == projectMember2.ProjectId);
                    projectMember2.ProjectId = projectMember.ProjectId;
                    projectMember2.Student = _context.Users.FirstOrDefault(x => x.Id == projectMember2.StudentId);
                    projectMember2.StudentId = StudentId2;
                    projectMember2.GroupName = projectMember.GroupName;
                    _context.Add(projectMember2);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("ProjectDetails", new { id = projectMember1.ProjectId });
            }

            var project = _context.Projects.FirstOrDefault(x => x.Id == projectMember.ProjectId);
            ViewData["Project"] = project;
            var classDetails = _context.ClassDetails.Where(x => x.ClassId == project.ClassId).Include(x => x.User).ToList();

            ViewData["StudentId1"] = new SelectList(classDetails, "UserId", "User.Fullname", StudentId1);
            ViewData["StudentId2"] = new SelectList(classDetails, "UserId", "User.Fullname", StudentId2);
            return View(projectMember);
        }
    }
}
