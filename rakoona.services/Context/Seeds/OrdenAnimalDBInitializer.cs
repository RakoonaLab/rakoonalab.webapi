﻿using Microsoft.EntityFrameworkCore;
using rakoona.core.Entities.Models.Pacientes;

namespace rakoona.core.Context.Seeds
{
    public static class OrdenAnimalDBInitializer
    {
        public static OrdenAnimal Carnivoro { get { return new OrdenAnimal { ExternalId = Guid.NewGuid().ToString(), Nombre = "Carnívoro" }; } }

        internal static void Seed(ModelBuilder builder)
        {
            builder.Entity<OrdenAnimal>().HasData(Carnivoro);
        }
    }
}
