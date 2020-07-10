﻿using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Logic;

namespace CourseREST.Controllers
{
    [Route("person")]
    [Route("[controller]")]
    [ApiController]
    public class PersonApiController : ControllerBase
    {
        public PersonController personController = new PersonController();

        [HttpGet]
        public List<Person> get()
        {
            return personController.FindAll();
        }
    }

    [Route("trainer")]
    [Route("[controller]")]
    [ApiController]
    public class TrainerApiController : ControllerBase
    {
        public PersonController personController = new PersonController();

        [HttpGet]
        public List<Person> get()
        {
            return personController.FindAllTrainers();
        }
    }
}