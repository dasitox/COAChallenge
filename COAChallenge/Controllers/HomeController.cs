using COAChallenge.DataAccess.ModelsEF;
using COAChallenge.UnitOfWork;
using COAChallenge.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace COAChallenge.Controllers
{
    [ApiController]
    [Route("/Home/usuarios")]
    public class HomeController : ControllerBase
    {        
        private readonly IUofW _uofW;
                
        public HomeController(IUofW uofW)
        {
            _uofW = uofW;
        }        

        [HttpGet]
        public ActionResult<IEquatable<User>> GetUsers()
        {
            try
            {
                var rest = _uofW.UserRepository.GetAll();
                if(rest.Count == 0)
                {
                    return NoContent();
                }
                return Ok(rest);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        
        [HttpGet("{Id}")]
        public ActionResult<User> GetUserById(int Id)
        {
            try
            {
                var selectedUser = _uofW.UserRepository.GetById(Id);
                if(selectedUser == null) return NotFound();
                
                return Ok(selectedUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        
        [HttpPost()]
        public IActionResult CreatUser(UserViewModel userViewModel)
        {
            try
            {
                if (!ModelState.IsValid) { return Problem("Modelo Invalido"); }                
                else
                {
                    userViewModel.IsActive = true;
                    User user = userViewModel.ToEntity();
                    if (_uofW.UserExist(user)) { return Problem("Uno o Mas Campos Ya Existen, Intentolo Nuevamente"); }
                    _uofW.UserRepository.Insert(user);
                    _uofW.Commit();
                    
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        
        [HttpPut("{Id}")]
        public ActionResult<User> EditUser(UserViewModel userVM, int Id)
        {
            try
            {
                var selectedUser = _uofW.UserRepository.GetById(Id);
                
                if (selectedUser == null) return NotFound();
                else
                {
                    User newUser = userVM.ToEntityModify(selectedUser,userVM);                    
                    _uofW.UserRepository.Update(newUser);
                    _uofW.Commit();

                    return Ok(newUser);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
                
        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(int Id)
        {
            try
            {
                var selectedUser = _uofW.UserRepository.GetById(Id);
                
                if (selectedUser == null) return NotFound();
                else 
                {
                    _uofW.UserRepository.Delete(selectedUser);
                    _uofW.Commit();
                    return RedirectToAction("GetUsers");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
