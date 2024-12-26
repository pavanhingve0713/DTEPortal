using DTEPortal.BusinessLayer.Masters;
using DTEPortal.Entities.Modals;
using DTEPortal.Entities.ViewModels;
using DTEPortal.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DTEPortal.Controllers.Masters.LocationMaster
{
    public class DivisionMasterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //Constructor for intialize objects
        public DivisionMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Retrieve data using the business layer
                DivisionMasterBL divisionBAL = new(_unitOfWork);
                var divisionData = await divisionBAL.GetAllDivisionAsync().ConfigureAwait(true);

                // Transform the data into the required view model
                var divisionList = (from division in divisionData
                                    select new MstDivisionVM
                                    {
                                        DivisionId = division.DivisionId,
                                        DivisionNameEng = division.DivisionNameEng,
                                        DivisionNameHin = division.DivisionNameHin,
                                        DivisionCode = division.DivisionCode,
                                        StateNameEng = division.MstState.StateNameEng,
                                        IsActive = division.IsActive
                                    }).OrderByDescending(x => x.DivisionId).ToList();

                // Pass the data to the view
                return View(divisionList);
            }
            catch
            {
                // Return an empty list in case of an error
                return View(new List<MstDivisionVM>());
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                StateMasterBL stateMasterBL = new(_unitOfWork);
                var StateList = await stateMasterBL.GetAllStateAsync();
                ViewBag.mstStateList = StateList.Where(x => x.IsActive == true).OrderBy(b => Convert.ToInt32(b.StateCode)).Select(statlist => new
                {
                    StateId = statlist.StateId,
                    StateNameEng = statlist.StateCode + "-" + statlist.StateNameEng
                }).ToList();
                if (TempData["Division"] == null)
                {
                    return View();
                }
                else
                {
                    var value = ViewBag.Get<MstDivision>("MstDivision");
                    //MstDivision mstDivision = TempData["Division"] as MstDivision;
                    return View(value);
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //Method for Save Division Detail
        public async Task<IActionResult> Create(MstDivision mstDivision)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DivisionMasterBL divisionBAL = new(_unitOfWork);
                    // Asynchronous call to get divisions
                    var ExistCode = (await divisionBAL.GetAllDivisionAsync()).Where(x => x.DivisionCode == mstDivision.DivisionCode).FirstOrDefault();
                    if (ExistCode == null)
                    {
                       
                        await divisionBAL.InsertDivisionAsync(mstDivision); // Ensure InsertDivisionAsync works properly
                        ModelState.Clear();
                        TempData["Message"] = "Division inserted successfully."; // Direct success message
                        TempData["Type"] = 1; // Success code
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Message"] = "Code No. : " + mstDivision.DivisionCode + " already exists."; // Direct error message
                        TempData["Type"] = 2; // Warning code

                        StateMasterBL stateMasterBL = new(_unitOfWork);
                        var StateList = await stateMasterBL.GetAllStateAsync();
                        ViewBag.mstStateList = StateList.Where(x => x.IsActive == true).OrderBy(b => Convert.ToInt32(b.StateCode)).Select(statlist => new
                        {
                            StateId = statlist.StateId,
                            StateNameEng = statlist.StateCode + "-" + statlist.StateNameEng
                        }).ToList();
                        mstDivision.DivisionCode = "";
                        TempData["Division"] = mstDivision; // Direct TempData setting
                        return RedirectToAction("Create");
                    }
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "An error occurred while processing your request."; // Direct error message
                    TempData["Type"] = 3; // Error code
                    return RedirectToAction("Create");
                }
            }
            else
            {
                TempData["Message"] = "Please fill in all mandatory fields."; // Direct mandatory field message
                TempData["Type"] = 2; // Warning code
                return RedirectToAction("Create");
            }
        }

        // Edit (GET) method for fetching the existing Division details based on DivisionId
        [HttpGet]
        public async Task<IActionResult> Edit(int id = 0)
        {
            if (id == 0)
            {
                TempData["Message"] = "Record not found.";
                TempData["Type"] = "Error";
                return RedirectToAction("Index");
            }
            else
            {
                DivisionMasterBL divisionBL = new(_unitOfWork);
                MstDivision mstDivision = await divisionBL.GetDivisionByIdAsync(id);
                try
                {
                    if (mstDivision != null)
                    {
                        StateMasterBL stateMasterBL = new(_unitOfWork);
                        var StateList = await stateMasterBL.GetAllStateAsync();
                        ViewBag.mstStateList = StateList.Where(x => x.IsActive == true)
                                                         .OrderBy(b => Convert.ToInt32(b.StateCode))
                                                         .Select(statlist => new
                                                         {
                                                             StateId = statlist.StateId,
                                                             StateNameEng = statlist.StateCode + "-" + statlist.StateNameEng
                                                         }).ToList();
                        return View(mstDivision);
                    }
                    else
                    {
                        TempData["Message"] = "Record not found.";
                        TempData["Type"] = "Error";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                    TempData["Message"] = "An error occurred while processing your request.";
                    TempData["Type"] = "Error";
                    return RedirectToAction("Index");
                }
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MstDivision mstDivision)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DivisionMasterBL divisionBL = new(_unitOfWork);
                    var ExistCode = divisionBL.GetAllDivisionAsync().Result
                                              .Where(s => s.DivisionCode == mstDivision.DivisionCode && s.DivisionId != mstDivision.DivisionId)
                                              .FirstOrDefault();
                    if (ExistCode == null)
                    {
                        var response = await divisionBL.GetDivisionByIdAsync(mstDivision.DivisionId);
                        if (response != null)
                        {
                            // Update the division record with new values
                            response.StateId = mstDivision.StateId;
                            response.DivisionNameEng = mstDivision.DivisionNameEng;
                            response.DivisionNameHin = mstDivision.DivisionNameHin;
                            response.DivisionCode = mstDivision.DivisionCode;
                            response.IsActive = mstDivision.IsActive;
                         

                            await divisionBL.UpdateDivision(response);
                            TempData["Message"] = "Division updated successfully.";
                            TempData["Type"] = "Success";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["Message"] = "Record not found.";
                            TempData["Type"] = "Error";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Code No. : " + mstDivision.DivisionCode + " already exists.";
                        TempData["Type"] = "Warning";
                        return RedirectToAction("Edit", new { Id = mstDivision.DivisionId });
                    }
                }
                catch (Exception)
                {
                    TempData["Message"] = "An error occurred while processing your request.";
                    TempData["Type"] = "Error";
                    return RedirectToAction("Edit", new { Id = mstDivision.DivisionId });
                }
            }
            else
            {
                TempData["Message"] = "Please fill in all mandatory fields.";
                TempData["Type"] = "Warning";
                return RedirectToAction("Edit", new { Id = mstDivision.DivisionId });
            }
        }







    }
}
