using AuthAPI.Data.Dto;
using AutoMapper;
using ItemAPI.Data;
using ItemAPI.Models;
using ItemAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ItemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        protected ResponseDto _responseDto;
        private IMapper _mapper;

        public ItemsAPIController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new();
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetItems()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            IEnumerable<Item> items = _db.Items.Where(x => x.UserId == userId).ToList();
            if (items == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "No items found";
                return NotFound(_responseDto);
            }
            
            _responseDto.Result = _mapper.Map<IEnumerable<ItemDto>>(items);

            return Ok(_responseDto);
        }

        [HttpPost()]
        public IActionResult CreateItem(UpsertItemDto request)
        {
            var item = _mapper.Map<Item>(request);
            item.Id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ModelState.Values.ToString();
                return BadRequest(_responseDto);
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            item.UserId = userId;
            item.Created_at = DateTime.UtcNow;

            _db.Items.Add(item);
            _db.SaveChanges();

            _responseDto.Result = _mapper.Map<ItemDto>(item);

            return Ok(_responseDto);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetItem(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var item = _db.Items.FirstOrDefault(i => i.Id == id && i.UserId == userId);

            if (item == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "No items found";
                return NotFound(_responseDto);
            }

            _responseDto.Result = _mapper.Map<ItemDto>(item);

            return Ok(_responseDto);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateItem(Guid id, UpsertItemDto request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var item = _mapper.Map<Item>(request);
            item.Id = id;
            item.UserId = userId;
            item.Updated_at = DateTime.UtcNow;

            if (!ModelState.IsValid)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ModelState.Values.ToString();
                return BadRequest(_responseDto);
            }

            _db.Items.Update(item);
            _db.SaveChanges();
            _responseDto.Result = _mapper.Map<ItemDto>(item);

            return Ok(_responseDto);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteItem(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var item = _db.Items.FirstOrDefault(i => i.Id == id && i.UserId == userId);
            if (item == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "No items found";
                return NotFound(_responseDto);
            }

            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok(_responseDto);
        }
    }
}
