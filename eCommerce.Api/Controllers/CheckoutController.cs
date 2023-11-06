using eCommerce.Api.Models;
using eCommerceApp.Application.Features.Cart.Queries.GetCurrentUserCart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator _mediator;
        private const string secret = "whsec_...";
        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-session")]
        public async Task<ActionResult> CreateSession(CheckOutRequest request)
        {
            var domain = "http://localhost:4242";
            try
            {
                // Assuming you have a list of products
                var cart = await _mediator.Send(new GetCurrentUserCartQuery()); // Replace this with your method to get the list of products

                var lineItems = new List<SessionLineItemOptions>();

                foreach (var product in cart.Items)
                {
                    lineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            ProductData = new()
                            {
                                Name = product.ProductName,
                            },
                            Currency = "pln", // Replace with your currency code
                            UnitAmount = (long)(product.UnitPrice * 100), // Convert decimal price to the lowest currency unit
                        },
                        Quantity = product.Quantity,
                    });
                }

                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" },
                    LineItems = lineItems,
                    Mode = "payment",
                    SuccessUrl = request.SuccessUrl,
                    CancelUrl = domain + "?canceled=true",
                };
                var service = new SessionService();
                Session session = service.Create(options);

                var x = JsonConvert.SerializeObject(session,Formatting.Indented);
                return Ok(x);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return BadRequest(new { message = "Error creating Stripe session", error = ex.Message });
            }
        }

        [HttpPost("order-placed")]
        public async Task<IActionResult> StripeWebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                  json,
                  Request.Headers["Stripe-Signature"],
                  secret
                );

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
