namespace Library.Persistence.Migrations
{
    using Library.Domain.Entities;
    using Library.Persistence.Context;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationContext context)
        {
            context.Books.Add(new Book
            {
                Title = "Padr�es de Arquitetura de Aplica��es Corporativas",
                Subject = "Informatica",
                Publisher = "Bookman",
                Author = "Martin Fowler",
                PublishDate = DateTime.Now.AddMonths(-2)
            });
            context.Books.Add(new Book
            {
                Title = "C�digo Limpo",
                Subtitle = "Habilidades Pr�ticas Do Agile Software",
                Subject = "Informatica",
                Publisher = "Alta Books",
                Author = "Robert Martin",
                PublishDate = DateTime.Now.AddMonths(-2)
            });
        }
    }
}
