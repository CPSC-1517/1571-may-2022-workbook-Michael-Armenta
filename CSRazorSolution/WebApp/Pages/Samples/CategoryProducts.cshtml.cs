using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
using WebApp.Helpers;
#endregion

namespace WebApp.Pages.Samples
{
    public class CategoryProductsModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;

        public CategoryProductsModel(CategoryServices categoryyservices,
                                        ProductServices productservices)
        {
            _categoryServices = categoryyservices;
            _productServices = productservices;
        }
        #endregion
        //  this property is being used as the routing parameter
        //  the SupportsGet = true indicates that the parameter
        //      supports the OnGet issued by the RedirectToPage
        [BindProperty(SupportsGet = true)]
        public int? categoryid { get; set; }

        public List<Category> CategoryList { get; set; }
        
        /// <summary>
        /// why Feedback needs to be carried to the web page which will call
        ///     the OnGet (second trip to server) to obtain the data to display
        ///     on the browser.
        /// </summary>
        [TempData]
        public string Feedback { get; set; }
        public void OnGet()
        {
            PopulateLists();
        }

        public void PopulateLists()
        {
            CategoryList = _categoryServices.Category_List();
        }

        public IActionResult OnPostSearch()
        {
            if(categoryid == 0)
            {
                Feedback = "Select a category to view the products for maintenance";
            }
            return RedirectToPage(new {categoryid = categoryid});
        }
        public IActionResult OnPostClear()
        {
            Feedback = "";
            categoryid = 0;
            ModelState.Clear();
            return RedirectToPage(new { categoryid = categoryid });
        }
    }
}
