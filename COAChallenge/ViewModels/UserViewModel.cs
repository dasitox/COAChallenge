using COAChallenge.DataAccess.ModelsEF;
using System.ComponentModel.DataAnnotations;

namespace COAChallenge.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre del Usuario"), Display(Name = "Nombre")]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email es requerido"), Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email invalido, intentelo nuevamente")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefono es requerido"), Display(Name = "Telefono")]
        [Phone(ErrorMessage = "El campo Telefono no es un número de teléfono válido.")]
        public string Telephone { get; set; }
        public bool IsActive { get; set; }

        public User ToEntity()
        {
            User user = new User();
            user.Id = Id;
            user.Name = Name;
            user.Email = Email;
            user.Telephone = Telephone;
            user.IsActive = IsActive;

            return user;
        }

        public User ToEntityModify(User user, UserViewModel userVM)
        {            
            user.Id = user.Id;
            user.Name = userVM.Name;
            user.Email = userVM.Email;
            user.Telephone = userVM.Telephone;
            userVM.IsActive = user.IsActive;

            return user;
        }
    }
}
