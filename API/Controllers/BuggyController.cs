using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        public DataContext _context { get; }
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret(){
            return "secure text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFount(){
            var thing = _context.Users.Find(-1);
            if(thing == null){
                return NotFound();                
            }
            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError(){
                               
            var thing = _context.Users.Find(-1);
            var thingtoreturn = thing.ToString();
            return thingtoreturn;
            
        }

        
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest(){
            return BadRequest("Bad Request");
        }
    }

}