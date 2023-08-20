using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;


namespace CustomerTest.Factory
{
    public class DatabaseFactory
    {        
        //Creates an in memory EF database with a new guid so each request is returned a new database
        public static CRUDContext Create()
        {            
            var options = new DbContextOptionsBuilder<CRUDContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            return new CRUDContext(options);
        }
    }
}
