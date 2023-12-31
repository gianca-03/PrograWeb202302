﻿using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryDAL categoryDal;

        private CategoryModel Convertir(Category category)
        {
            return (new CategoryModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            });
        }

        private Category Convertir(CategoryModel category)
        {
            return (new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            });
        }

        #region Constructores
        public CategoryController()
        {
            categoryDal = new CategoryDALImpl();    
        }

        #endregion

        #region Consultas

        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Category> categories = categoryDal.GetAll();
            List<CategoryModel> models = new List<CategoryModel>();

            foreach (var category in categories)
            {
                models.Add(Convertir(category));
            }

            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Category category = categoryDal.Get(id);

            return new JsonResult(Convertir(category));
        }

        #endregion

        #region Agregar

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        #endregion

        #region Modificar

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        #endregion

        #region Eliminar

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion

    }

}
