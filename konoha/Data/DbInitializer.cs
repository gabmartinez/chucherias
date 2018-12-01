using konoha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace konoha.Data
{
    public class DbInitializer
    {
        public static void Initializer(DBContext context){

            context.Database.EnsureCreated();

            //Buscar si existen registros
            if (context.Category.Any())
            {
                return;
            }

            var category = new Category[]
            {
                new Category{Name="Shirts", Acronym="Shir", Desciption="The best in the market"}
            };

            foreach(Category c in category)
            {
                context.Category.Add(c);

            }

             context.SaveChanges();
       }
    }
}
