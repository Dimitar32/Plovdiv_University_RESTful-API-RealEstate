using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateManagmentSystem.Data;
using RealEstateManagmentSystem.Models;

namespace RealEstateManagmentSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateAgencyController : Controller
    {
        private readonly RealEstateManagmentContext _context;
        public RealEstateAgencyController(RealEstateManagmentContext context)
        {
            _context = context;
        }

        [HttpGet("Property/GetAllProperties")]
        public async Task<ActionResult<IEnumerable<Property>>> GetAllProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        [HttpGet("Property/GetPropertyById")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            Property property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        [HttpPost("Property/AddProperty")]
        public async Task<IActionResult> AddProperty(string address, string category, int ownerId, string status)
        {
            if (category == null || status == null || address == null)
            {
                return BadRequest("Property data is null.");
            }

            Owner owner = await _context.Owners.FindAsync(ownerId);
            
            if (owner == null)
            {
                return NotFound($"Owner with ID {ownerId} not found.");
            }

            Property property = new Property(address, category, owner, status);

            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPropertyById), new { id = property.Id }, property);
        }

        [HttpPut("Property/UpdatePropertyStatus")]
        public async Task<IActionResult> UpdatePropertyStatus(int id, string newStatus)
        {
            Property property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound($"Property with ID {id} not found.");
            }

            property.Status = newStatus;
            await _context.SaveChangesAsync();

            return Ok(property);
        }

        [HttpDelete("Property/DeleteProperty")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            Property property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound($"Property with ID {id} not found.");

            }
    
            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return Ok(new { message = "The property was deleted successfully" });

        }

        [HttpGet("Owners/SelectAllOwners")]
        public async Task<ActionResult<IEnumerable<Owner>>> SelectAllOwners()
        {
            return await _context.Owners.ToListAsync();
        }

        [HttpGet("Owners/GetOwnerById")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            Owner owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        [HttpGet("Owners/SelectOwnersByName")]
        public async Task<ActionResult<IEnumerable<Tenant>>> SelectOwnersByName(string name)
        {
            var owners = await _context.Owners.Where(t => t.Name == name).ToListAsync();

            return Ok(owners);
        }

        [HttpPost("Owners/AddOwner")]
        public async Task<IActionResult> AddOwner(string name, string phone, string email)
        {
            if (name == null || phone == null || email == null)
            {
                return BadRequest("Property data is null.");
            }

            Owner owner = new Owner(name, phone, email);

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOwnerById), new { id = owner.Id }, owner);
        }

        [HttpPut("Owners/UpdateOwnerName")]
        public async Task<IActionResult> UpdateOwnerName(int id, string newName)
        {
            Owner owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound($"Owner with ID {id} not found.");
            }

            owner.Name = newName;
            await _context.SaveChangesAsync();

            return Ok(owner);
        }

        [HttpPut("Owners/UpdateOwnerContacts")]
        public async Task<IActionResult> UpdateOwnerContacts(int id, string phone, string email)
        {
            Owner owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound($"Owner with ID {id} not found.");
            }

            if (phone == null || email == null || phone == "" || email == "")
            {
                return NotFound($"Not valid phone or email.");
            }

            owner.Phone = phone;
            owner.Email = email;
            await _context.SaveChangesAsync();

            return Ok(owner);
        }

        [HttpDelete("Owners/DeleteOwner")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound($"Owner with ID {id} not found.");
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return Ok(new { message = "The owner was deleted successfully" });
        }

        [HttpGet("Tenants/SelectAllTenants")]
        public async Task<ActionResult<IEnumerable<Tenant>>> SelectAllTenants()
        {
            return await _context.Tenants.ToListAsync();
        }

        [HttpGet("Tenants/GetTenantById")]
        public async Task<IActionResult> GetTenantById(int id)
        {
            Tenant tenant = await _context.Tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(tenant);
        }

        [HttpGet("Tenants/SelectTenantsByName")]
        public async Task<ActionResult<IEnumerable<Tenant>>> SelectTenantsByName(string name)
        {
            var tenants = await _context.Tenants.Where(t => t.Name == name).ToListAsync();

            return Ok(tenants);
        }

        [HttpPost("Tenants/AddTenant")]
        public async Task<IActionResult> AddTenant(string name, string phone, string email)
        {
            if (name == null || phone == null || email == null)
            {
                return BadRequest("Property data is null.");
            }

            Tenant tenant = new Tenant(name, phone, email);

            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTenantById), new { id = tenant.Id }, tenant);
        }

        [HttpPut("Tenants/UpdateTenantName")]
        public async Task<IActionResult> UpdateTenantName(int id, string newName)
        {
            Tenant tenant = await _context.Tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound($"Tenant with ID {id} not found.");
            }

            tenant.Name = newName;
            await _context.SaveChangesAsync();

            return Ok(tenant);
        }

        [HttpPut("Tenants/UpdateTenantContacts")]
        public async Task<IActionResult> UpdateTenantContacts(int id, string phone, string email)
        {
            Tenant tenant = await _context.Tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound($"Tenant with ID {id} not found.");
            }

            if (phone == null || email == null || phone == "" || email == "")
            {
                return NotFound($"Not valid phone or email.");
            }

            tenant.Phone = phone;
            tenant.Email = email;
            await _context.SaveChangesAsync();

            return Ok(tenant);
        }

        [HttpDelete("Tenants/DeleteTenant")]
        public async Task<IActionResult> DeleteTenant(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);

            if(tenant == null)
            {
                return NotFound($"Tenant with ID {id} not found.");
            }

            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();

            return Ok(new { message = "The tenant was deleted successfully" });
        }

        [HttpGet("LeaseAgreements/SelectAllLeaseAgreements")]
        public async Task<ActionResult<IEnumerable<LeaseAgreement>>> SelectAllLeaseAgreements()
        {
            return await _context.LeaseAgreements.ToListAsync();
        }

        [HttpGet("LeaseAgreements/GetLeaseAgreementById")]
        public async Task<IActionResult> GetLeaseAgreementById(int id)
        {
            LeaseAgreement la = await _context.LeaseAgreements.FindAsync(id);

            if (la == null)
            {
                return NotFound();
            }

            return Ok(la);
        }

        [HttpPost("LeaseAgreement/AddLeaseAgreement")]
        public async Task<IActionResult> AddLeaseAgreement(int propertyId, int tenantId, DateTime startDate, DateTime endDate, string price)
        {
            if (price == null)
            {
                return BadRequest("Price data is null.");
            }

            Property property = await _context.Properties.FindAsync(propertyId);

            if (property == null)
            {
                return NotFound($"Property with ID {propertyId} not found.");
            }

            Tenant tenant = await _context.Tenants.FindAsync(tenantId);

            if (tenant == null)
            {
                return NotFound($"Tenant with ID {tenantId} not found.");
            }

            LeaseAgreement la = new LeaseAgreement(property, tenant, startDate, endDate, price);

            _context.LeaseAgreements.Add(la);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLeaseAgreementById), new { id = la.Id }, la);
        }

        [HttpPut("LeaseAgreements/UpdateLeaseAgreementPrice")]
        public async Task<IActionResult> UpdateLeaseAgreementPrice(int id, string newPrice)
        {
            LeaseAgreement la = await _context.LeaseAgreements.FindAsync(id);

            if (la == null)
            {
                return NotFound($"LeaseAgreement with ID {id} not found.");
            }

            la.Price = newPrice;
            await _context.SaveChangesAsync();

            return Ok(la);
        }

        [HttpDelete("LeaseAgreements/DeleteLeaseAgreements")]
        public async Task<IActionResult> DeleteLeaseAgreements(int id)
        {
            var la = await _context.LeaseAgreements.FindAsync(id);

            if (la == null)
            {
                return NotFound($"LeaseAgreement with ID {id} not found.");
            }

            _context.LeaseAgreements.Remove(la);
            await _context.SaveChangesAsync();

            return Ok(new { message = "The lease agreement was deleted successfully" });
        }
    }
}
