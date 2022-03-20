using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
//Change to project name
namespace ToDoList.Models
{
  //Change to project name
  public class ToDoListContextFactory : IDesignTimeDbContextFactory<ToDoListContext>
  {
    //Change to project name
    ToDoListContext IDesignTimeDbContextFactory<ToDoListContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
      //Change to project name
      var builder = new DbContextOptionsBuilder<ToDoListContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));
      //Change to project name
      return new ToDoListContext(builder.Options);
    }
  }
}