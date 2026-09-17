using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using SindhBankApplicationTracking.Models;

namespace SindhBankApplicationTracking.Controllers
{
    public class TrackingController : Controller
    {
        private readonly string _connectionString;

        public TrackingController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SindhBankTracking")
                ?? throw new InvalidOperationException("Connection string 'SindhBankTracking' not found in appsettings.json.");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TrackingViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string trackingId)
        {
            var model = new TrackingViewModel { TrackingId = trackingId, HasSearched = true };
            var key = trackingId?.Trim().ToUpperInvariant() ?? string.Empty;

            if (key.Length > 0)
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_GetApplicationStatus", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@TrackingId", key);

                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    model.IsFound = true;
                    model.Status = Enum.Parse<ApplicationStatus>(reader.GetString(reader.GetOrdinal("Status")));
                }
            }

            return View(model);
        }
    }
}