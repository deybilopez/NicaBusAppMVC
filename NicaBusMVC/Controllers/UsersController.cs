using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using NicaBusMVC.Application.Command;
using NicaBusMVC.Configuration;
using NicaBusMVC.Data;
using NicaBusMVC.Models;

namespace NicaBusMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ICommandHandler<UserDTO> _permissionCommandHandler;
        private readonly ICommandHandler<RemoveByIdCommand> _removeCommandHandler;
        private readonly IQueryHandler<User, QueryByIdCommand> _permissionQueryHandler;

        //private readonly NicaBusMVCContext _context;

        public UsersController(
            ICommandHandler<UserDTO> permissionCommandHandler,
            ICommandHandler<RemoveByIdCommand> removeCommandHandler,
            IQueryHandler<User, QueryByIdCommand> permissionQueryHandler
            )
        {
            _permissionCommandHandler = permissionCommandHandler;
            _removeCommandHandler = removeCommandHandler;
            _permissionQueryHandler = permissionQueryHandler;
        }



        // GET: Users
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _permissionQueryHandler.GetAll();
        }

        // GET: Users/Details/5



        //Esto me dio error

        //public async Task<ActionResult<User>> GetByIdAsync(int id)
        //{
        //    var user = await _permissionQueryHandler.GetOne(new QueryByIdCommand()
        //    {
        //        id = id
        //    });

        //}

        //// GET: Users/Create
        //public IActionResult Create()
        //{
        //    ViewData["DetallesViajeId"] = new SelectList(_context.DetallesViaje, "Id", "Id");
        //    ViewData["RutaId"] = new SelectList(_context.Ruta, "Id", "Id");
        //    return View();
        //}

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,DetallesViajeId,RutaId")] UserDTO user)
        {

            _permissionCommandHandler.Execute(user);
            return CreatedAtAction("GetPermission", new { id = user.Id }, user);

        }



        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,DetallesViajeId,RutaId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            try
            {
                //_permissionCommandHandler.Execute(QueryByIdCommand(){

                //})

                return CreatedAtAction("GetPermission", new { id = user.Id }, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
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

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _permissionCommandHandler == null)
            {
                return NotFound();
            }

            var user = await _permissionQueryHandler.GetAll();
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_permissionCommandHandler == null)
            {
                return Problem("Entity set 'NicaBusMVCContext.User'  is null.");
            }

            _removeCommandHandler.Execute(new RemoveByIdCommand()
            {
                Id = id
            });

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _permissionQueryHandler.GetAll();
        }
    }
}
