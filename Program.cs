using System;
using Microsoft.AspNetCore.Mvc;
using Backend;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:5000");

var EndpointManager = new EndPointManager(app);

app.MapGet("/hello123/{who1}/{who2}/{who3}", (string who1, string who2, string who3) => $"Hello World from {who1}, {who2}, and {who3}!!!");

app.Run();


record Person(string Name, int Age);