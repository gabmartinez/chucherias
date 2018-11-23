using konoha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace konoha.Data
{
    public class DbInitializer
    {
        public static void Initializer(konohaContext context){

            context.Database.EnsureCreated();

            //Buscar si existen registros
            if (context.Category.Any())
            {
                return;
            }

            var category = new Category[]
            {
                new Category{Name="Jose Hernandez", Acronym="jos", Desciption="Un hombre solitario"}
            };

            foreach(Category c in category)
            {
                context.Category.Add(c);

            }

             context.SaveChanges();
       }
    }
}
