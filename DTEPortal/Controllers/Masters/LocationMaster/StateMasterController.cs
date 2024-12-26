using DTEPortal.BusinessLayer.Masters;
using DTEPortal.Entities.Modals;
using DTEPortal.Entities.ViewModels;
using DTEPortal.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DTEPortal.Controllers.Masters.LocationMaster
{
    public class StateMasterController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public StateMasterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // StateRepository से डेटा प्राप्त करना (Async method)
            var states = await _unitOfWork.statesRepository.GetAllStateAsync();

            // MstState को MstStateViewModel में map करना
            var viewModel = states.Select(state => new MstStateViewModel
            {
                StateId = state.StateId,
                StateNameEng = state.StateNameEng,
                StateNameHin = state.StateNameHin,
                StateCode = state.StateCode,
                IsActive = state.IsActive
            }).ToList();

            // View में ViewModel भेजना
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MstStateViewModel mstStateViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Business Layer Logic (BL) for state operations
                    StateMasterBL stateMasterBL = new(_unitOfWork);

                    // Get the list of all states asynchronously
                    var allStates = await stateMasterBL.GetAllStateAsync();

                    // Checking if StateCode or StateNameEng already exists
                    var isCodeNoExists = allStates.FirstOrDefault(s => s.StateCode == mstStateViewModel.StateCode);
                    var isStateNameEngExists = allStates.FirstOrDefault(s => s.StateNameEng == mstStateViewModel.StateNameEng);

                    if (isCodeNoExists != null)
                    {
                        // If the StateCode already exists
                        ViewBag.Message = "Code No. : " + mstStateViewModel.StateCode + " already exists.";
                        return View(mstStateViewModel); // Return the same view with the message
                    }
                    else if (isStateNameEngExists != null)
                    {
                        // If the State Name (in English) already exists
                        ViewBag.Message = "State Name (In English) : " + mstStateViewModel.StateNameEng + " already exists.";
                        return View(mstStateViewModel); // Return the same view with the message
                    }
                    else
                    {
                        // If no duplicates found, insert the new state
                        MstState mstState = new MstState
                        {
                            StateNameEng = mstStateViewModel.StateNameEng,
                            StateNameHin = mstStateViewModel.StateNameHin,
                            StateCode = mstStateViewModel.StateCode,
                            IsActive = mstStateViewModel.IsActive,
                            CreatedBy = 0, // Default value if UserId is not available
                            CreatedOn = DateTime.Now,
                            IPAddress = "NA" // Optionally store the IP Address
                        };

                        // Insert the new state
                        await stateMasterBL.InsertStateAsync(mstState);

                        // Clear the ModelState to ensure a fresh form for the next request
                        ModelState.Clear();

                        // Success message
                        ViewBag.Message = "State added successfully.";

                        // Optionally, redirect to another action (like Index) if desired
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if necessary
                    ViewBag.Message = "An error occurred while processing your request. " + ex.Message;
                    return View(mstStateViewModel); // Return the same view with error message
                }
            }
            else
            {
                // If the model is invalid, return the same view with validation messages
                ViewBag.Message = "Please fill in all required fields.";
                return View(mstStateViewModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Int16 id = 0)
        {
            if (id == 0)
            {
                ViewBag.Message = "State not found.";
                return RedirectToAction("Index");
            }

            try
            {
                // StateMasterBL के माध्यम से डेटा प्राप्त करना
                StateMasterBL stateMasterBL = new(_unitOfWork);
                var mstState = await stateMasterBL.GetStateByIdAsync(id);

                if (mstState == null)
                {
                    ViewBag.Message = "State not found.";
                    return RedirectToAction("Index");
                }
                else
                {
                    // MstState को MstStateViewModel में मैप करना
                    MstStateViewModel mstStateViewModel = new MstStateViewModel
                    {
                        StateCode = mstState.StateCode,
                        StateNameEng = mstState.StateNameEng,
                        StateNameHin = mstState.StateNameHin,
                        IsActive = mstState.IsActive,
                        StateId = mstState.StateId
                    };

                    return View(mstStateViewModel);
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "An error occurred while processing your request.";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MstStateViewModel mstStateViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Initialize StateMasterBL for state operations
                    StateMasterBL stateMasterBL = new(_unitOfWork);

                    var allStates = await stateMasterBL.GetAllStateAsync();

                    // Checking if StateCode or StateNameEng already exists
                    var isCodeNoExists = allStates.FirstOrDefault(s => s.StateCode == mstStateViewModel.StateCode && s.StateId != mstStateViewModel.StateId);
                    var isStateNameEngExists = allStates.FirstOrDefault(s => s.StateNameEng == mstStateViewModel.StateNameEng && s.StateId != mstStateViewModel.StateId);

                    if (isCodeNoExists != null)
                    {
                        // If the StateCode already exists
                        ViewBag.Message = "Code No. : " + mstStateViewModel.StateCode + " already exists.";
                        return View(mstStateViewModel); // Return the same view with the message
                    }
                    else if (isStateNameEngExists != null)
                    {
                        // If the State Name (in English) already exists
                        ViewBag.Message = "State Name (In English) : " + mstStateViewModel.StateNameEng + " already exists.";
                        return View(mstStateViewModel); // Return the same view with the message
                    }
                    else
                    {
                        // Fetch the existing state from the database by StateId
                        var response = await stateMasterBL.GetStateByIdAsync(mstStateViewModel.StateId);
                        if (response != null)
                        {
                            // Update the state details if found
                            response.StateNameEng = mstStateViewModel.StateNameEng;
                            response.StateNameHin = mstStateViewModel.StateNameHin;
                            response.StateCode = mstStateViewModel.StateCode;
                            response.IsActive = mstStateViewModel.IsActive;

                            // No UserId used here, simply updating the state
                            response.LastUpdatedOn = DateTime.Now;
                            response.IPAddress = "NA"; // Optionally, store the IP Address

                            // Update the state in the database
                            await stateMasterBL.UpdateState(response);

                            // Success message after update
                            ViewBag.Message = "State updated successfully.";

                            // Clear ModelState to ensure a fresh form for the next request
                            ModelState.Clear();

                            // Optionally, redirect to another action (like Index)
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            // If state not found, show error message
                            ViewBag.Message = "State not found.";
                            return View(mstStateViewModel); // Return the same view with the error message
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log exception if necessary
                    ViewBag.Message = "An error occurred while processing your request. " + ex.Message;
                    return View(mstStateViewModel); // Return the same view with the error message
                }
            }
            else
            {
                // If the model is invalid, return the same view with validation messages
                ViewBag.Message = "Please fill in all required fields.";
                return View(mstStateViewModel);
            }
        }

        //public async Task<JsonResult> DeleteRecord(Int16 id = 0)
        //{
        //    string[] returnList = new string[2];

        //    // If the ID is not valid (zero)
        //    if (id == 0)
        //    {
        //        returnList[0] = "1"; // Error code
        //        returnList[1] = "State could not be deleted."; // Error message
        //        TempData["Message"] = returnList[1];
        //        TempData["Type"] = returnList[0];
        //        return Json(returnList);
        //    }
        //    else
        //    {
        //        // StateMasterBL to fetch state details
        //        StateMasterBL stateMasterBL = new(_unitOfWork);
        //        MstState mstState = await stateMasterBL.GetStateByIdAsync(id);

        //        try
        //        {
        //            // If the state does not exist
        //            if (mstState == null)
        //            {
        //                returnList[0] = "1"; // Error code
        //                returnList[1] = "State could not be found to delete."; // Error message
        //                TempData["Message"] = returnList[1];
        //                TempData["Type"] = returnList[0];
        //                return Json(returnList);
        //            }
        //            else
        //            {
        //                // Check if the state is linked to any active divisions
        //                DivisionBAL divisionBL = new(_unitOfWork);
        //                var IsActiveCheck = divisionBL.GetAllDivisionAsync().Result.Where(x => x.StateId == mstState.StateId && x.IsActive == true).FirstOrDefault();

        //                if (IsActiveCheck != null)
        //                {
        //                    // If the state is already used in active divisions
        //                    returnList[0] = "2"; // Warning code
        //                    returnList[1] = "This state is already used in active divisions and cannot be deleted."; // Warning message
        //                    TempData["Message"] = returnList[1];
        //                    TempData["Type"] = returnList[0];
        //                    return Json(returnList);
        //                }
        //                else
        //                {
        //                    // Get IP address directly from HTTP context
        //                    string IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

        //                    // Set state as inactive and update details
        //                    mstState.IsActive = false;
        //                    mstState.LastUpdatedOn = DateTime.Now;
        //                    mstState.IPAddress = IPAddress;

        //                    // Update the state in the database
        //                    await stateMasterBL.UpdateState(mstState);

        //                    returnList[0] = "0"; // Success code
        //                    returnList[1] = "State successfully deleted."; // Success message
        //                    TempData["Message"] = returnList[1];
        //                    TempData["Type"] = returnList[0];
        //                    return Json(returnList);
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            // Handle exceptions without logging
        //            returnList[1] = "An error occurred while processing your request."; // Error message
        //            returnList[0] = "1"; // Error code
        //            TempData["Message"] = returnList[1];
        //            TempData["Type"] = returnList[0];
        //            return Json(returnList);
        //        }
        //    }
        //}

    }
}
