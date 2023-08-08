﻿using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private ICategoryDAL categoryDal;

        private CategoryModel Convertir(Category category)
        {
            return (new CategoryModel
            {
                CategoryID = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            });
        }

        private Category Convertir(CategoryModel category)
        {
            return (new Category
            {
                CategoryId = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
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
        public  async Task< JsonResult> Get()
        {
            IEnumerable<Category> categories = await categoryDal.GetAll();
            List<CategoryModel> models = new List<CategoryModel>();

            foreach (var category in categories)
            {
                models.Add(Convertir(category));
            }

            return new JsonResult(models);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task< JsonResult >Get(int id)
        {
            Category category = await categoryDal.Get(id);

            return new JsonResult(Convertir(category));
        }

        #endregion

        #region Agregar

        // POST api/<CategoryController>
        [HttpPost]
        public async Task <JsonResult> Post([FromBody] CategoryModel category)
        {
            categoryDal.Add(Convertir(category));
            return new JsonResult(category);
        }

        #endregion

        #region Modificar

        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CategoryModel category)
        {
            categoryDal.Update(Convertir(category));
            return new JsonResult(category);
        }

        #endregion

        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Category category = new Category
            {
                CategoryId = id
            };

            categoryDal.Remove(category);

        }

        #endregion

    }

}
