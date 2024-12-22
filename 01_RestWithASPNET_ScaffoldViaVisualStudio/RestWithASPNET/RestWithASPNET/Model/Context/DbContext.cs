
using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Business;
using RestWithASPNET.Business.Implementations;
using RestWithASPNETErudio.Model.Context;
namespace RestWithASPNET.Model.Context

{
    public class DbContext
    {
        public DbContext(DbContextOptions<MySQLContext> options)
        {
        }
    }
}