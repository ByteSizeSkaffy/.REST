using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Backend;

namespace Backend{
    public class Person{
        public int Id {get;set;}
        public string Name {get; set;}
        public int Age {get;set;}
    }

    public class FriendsWith{
        public int FromId {get; set;}
        public int ToId {get; set;}
    }
    public class inMemoryDb{
        public List<Person> Person {get; set;} 
        public List<FriendsWith> FriendShip {get; set;}

        public void inMemoryDatabase(){
            Person = new List<Person>();
            FriendShip = new List<FriendsWith>();
        }
    }
    public class EndPointManager{
        private WebApplication App {get;set;}
        private inMemoryDb Db {get;set;}
        public EndPointManager(WebApplication app){
            App = app;
            Db = new inMemoryDb();
            App.MapGet("/helloworld", ()=> Results.Ok("hello world"));
            App.MapPost("/Person", AddPerson);
        }
        private IResult AddPerson(Person person){
            var existingPerson = Db.Person.FirstOrDefault(p => p.Id == person.Id);
            if(existingPerson==null){
                return Results.BadRequest($"person with id: {person.Id} already exists");
            }
            Db.Person.Add(person);
            return Results.Ok("succeeded");
             
        }

    }
}