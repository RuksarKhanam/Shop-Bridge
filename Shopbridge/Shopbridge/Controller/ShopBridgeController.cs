using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shopbridge.Data;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ShopBridgeController : Controller
    {
        IConfiguration _iconfiguration;
        private readonly ApplicationDBContext _context;

        public ShopBridgeController(IConfiguration iconfiguration, ApplicationDBContext context)
        {
            _context = context;
            _iconfiguration = iconfiguration;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                List<ShopItem> list = new List<ShopItem>();
                list = _context.Items.Where(d => d.DocumentType == "shopitem").AsEnumerable().ToList();

                return Ok(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewItem([FromBody] ShopItem item)
        {
            try
            {
                item.Id = Guid.NewGuid().ToString();

                item.DocumentType = "shopitem";
                item.DateOfAddition = DateTime.UtcNow;
                item.IsAvailable = true;


                _context.SaveChanges();
                return Ok(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProgram([FromBody] ShopItem item)
        {
            try
            {
                var existingItem = new ShopItem();
                existingItem = _context.Items.Where(d => d.Id == item.Id && d.DocumentType == "shopitem").AsEnumerable().LastOrDefault();

                if (existingItem != null)
                {

                    existingItem.UpdatedOn = DateTime.UtcNow;
                    _context.Items.Update(existingItem);
                    _context.SaveChanges();

                    return Ok(existingItem);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteItem([FromQuery] string uId)
        {
            try
            {

                var item = _context.Items.Where(d => d.Id == uId).AsEnumerable().SingleOrDefault();
                item.IsAvailable = false;
                _context.Items.Update(item);

                _context.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}


