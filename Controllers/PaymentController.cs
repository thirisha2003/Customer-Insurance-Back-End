using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Controllers
{
    public class PaymentController : Controller
    {
        private readonly InsuranceContext _context;

        public PaymentController(InsuranceContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<Payment> GetPaymentDetailsById(int id)
        {
            var paymentDetails = _context.Payments.Find(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            return paymentDetails;
        }

        [HttpPost]
        public ActionResult<Payment> PostPaymentDetails(Payment paymentDetails)
        {
            _context.Payments.Add(paymentDetails);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPaymentDetailsById), new { id = paymentDetails.PaymentId }, paymentDetails);
        }

        [HttpPut("{id}")]
        public IActionResult PutPaymentDetails(int id, Payment paymentDetails)
        {
            if (id != paymentDetails.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetails).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePaymentDetails(int id)
        {
            var paymentDetails = _context.Payments.Find(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(paymentDetails);
            _context.SaveChanges();

            return NoContent();
        }
    }
}