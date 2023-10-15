﻿using ExerciseUI;
using ExerciseUI.Controllers;
using ExerciseUI.Model;
using ExerciseUI.Repositories;
using ExerciseUI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection collection = new();

collection.AddDbContext<ExerciseContext>(option =>
{
    option.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Exercises;Integrated Security=true");
})
    .AddScoped<IRepository<ExerciseModel>, ExerciseRepository<ExerciseModel>>()
    .AddScoped<IExerciseService<ExerciseModel>, ExerciseService>()
    .AddScoped<IExerciseController<ExerciseModel>, ExerciseController>();

ServiceProvider provider = collection.BuildServiceProvider();
var controller = provider.GetService<IExerciseController<ExerciseModel>>();

new UserInterface(controller);
