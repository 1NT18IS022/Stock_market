    using E_stock_market.Database;
using E_stock_market.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_stock_market.Controllers
{
    
    [Route("api/v1.0/[controller]")]
    [ApiController]
    [Authorize]

    public class MarketController : ControllerBase
    {
        private readonly DataContext context;
      private ILogger<MarketController> _logger;

        public MarketController(DataContext _context, ILogger<MarketController> logger)
        {

           _logger=logger;
            context = _context;
        }

        
       [HttpPost("company/register"), Authorize(Roles = "Admin")]
        public  ActionResult<string> register([FromBody] Cdata input)
        {
            var  data = context.CD.Where(x => x.Company_code == input.Company_code).FirstOrDefault<Cdata>();
            if (data==null )
            {
                


                if (input == null)
                {
                    _logger.LogError("the details entered to register company data is invalid");
                    return BadRequest("Enter proper details of company");
                }

                context.CD.AddAsync(input);
                context.SaveChanges();
                return Ok("company details added succesfully");
            }
            else
            {
                _logger.LogError("Company code is already used");
                return BadRequest("Company code is already used");
            }
               

    

        }

        [HttpGet("company/getall")]
        public async Task<ActionResult<Company_details[]>> getall()
        {
            var company_data = await context.CD.ToListAsync<Cdata>();

            var details = new List<Company_details>();
            var company_details = new Company_details();
            foreach (var company in company_data)
            {
                company_details.Company_code = company.Company_code;
                company_details.Company_name = company.Company_name;
                company_details.Company_ceo = company.Company_ceo;
                company_details.Company_turnover = company.Company_turnover;
                company_details.Company_website = company.Company_website;
                var stock_data = await context.Stocks.Where(x => x.Company_code == company.Company_code).ToListAsync<Stock>();
                Stock date = await context.Stocks.Where(x => x.Company_code == company.Company_code).FirstOrDefaultAsync<Stock>();
                foreach (var stock in stock_data)
                {
                    if (stock.Company_code == company.Company_code)
                    {
                        if (stock.Date_time >= date.Date_time)
                        {
                            company_details.Stock_price = stock.Stock_price;
                        }

                    }
                }
                details.Add(company_details);
                company_details = new Company_details();

            }


            return Ok(details);



        }

        [HttpGet("company/info/{id}")]
        public ActionResult<Company_details> company_fetch(int id)
        {
            var company_details = new Company_details();
            Cdata company =  context.CD.Where(x => x.Company_code == id).FirstOrDefault<Cdata>();

            if (company == null)
            {
                _logger.LogError("No company detail on given company code");
               return BadRequest("No company detail on given company code");
            }


            company_details.Company_code = company.Company_code;
            company_details.Company_name = company.Company_name;
            company_details.Company_ceo = company.Company_ceo;
            company_details.Company_turnover = company.Company_turnover;
            company_details.Company_website = company.Company_website;



            var stock_data =  context.Stocks.Where(x => x.Company_code == company.Company_code).ToList<Stock>();
            Stock date =  context.Stocks.Where(x => x.Company_code == company.Company_code).FirstOrDefault<Stock>();
            foreach (var stock in stock_data)
            {
                if (stock.Company_code == company.Company_code)
                {
                    if (stock.Date_time >= date.Date_time)
                    {
                        company_details.Stock_price = stock.Stock_price;
                    }

                }
            }


            return company_details;

        }

        [HttpDelete("company/delete/{id}"),Authorize(Roles ="Admin")]
        public string Delete_company(int id)
        {
            Cdata company =  context.CD.Where(x => x.Company_code == id).FirstOrDefault<Cdata>();
            if (company == null)
            {
                _logger.LogError("Company details not found");
                return "Company details not found";

            }
            

         
           
            var stock_data =  context.Stocks.ToList<Stock>();
            foreach (var stock in stock_data)
            {
                if (stock.Company_code == id)
                {
                    context.Stocks.Remove(stock);
                     context.SaveChanges();
                }
            }

            context.CD.Remove(company);
             context.SaveChanges();






            return "deleted successfully";



        }

        [HttpPost("stock/add/{id}"), Authorize(Roles = "Admin")]
        public string add_stock(int id, Stock input)
        {
            Cdata company =  context.CD.Where(x => x.Company_code == id).FirstOrDefault<Cdata>();
            if (company == null)
            {_logger.LogError("Company details not found");
                return "Company details not found";
            }

            if (input == null)
            {_logger.LogWarning("Stock details entered are invalid");
                return "Enter proper details of stock";
            }

            input.Company_code = id;
            input.Date_time = DateTime.Now;

             context.Stocks.AddAsync(input);
             context.SaveChangesAsync();

            return "Stock details added scuccessfully";

        }

        [HttpGet("stock/get/{id}/{startdate}/{enddate}")]
        public async Task<ActionResult<Stock>> Stock_details(int id, DateTime startdate, DateTime enddate)
        {

            Cdata company = await context.CD.Where(x => x.Company_code == id).FirstOrDefaultAsync<Cdata>();
            if (company == null)
            {
                _logger.LogError("company details not found ");
                return BadRequest("Company details not found");
            }

            var stock_details = new List<Stock>();
           var  stock_data = await context.Stocks.Where(x => x.Company_code == company.Company_code).ToListAsync<Stock>();

            foreach (var stock in stock_data)
            {
                if (stock.Date_time>=startdate && stock.Date_time<=enddate )
                {
                    stock_details.Add(stock);
                }
            }


            /*   stock_details = await context.Stocks.Where(x =>
               x.Company_code == company.Company_code &&
               x.Date_time >= startdate &&
               x.Date_time <= enddate).ToListAsync<Stock>();
            */
            return Ok(stock_details);

        }

        [HttpGet("all_stocks")]
        public List<Stock> get_all_stocks(int data)
        {
            var stocks = new List<Stock>();

            stocks=context.Stocks.Where(x=>x.Company_code==data).ToList();

            return stocks;
        }





    }
}
