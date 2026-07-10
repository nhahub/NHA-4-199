// ================================================================
// Models/DataTableViewModel.cs
// Strongly-typed model consumed by Views/Shared/Components/_DataTable.cshtml.
// Any HR module (Employees, Requisitions, Payroll register, etc.) builds one
// of these in its controller/action and passes it to the partial:
//
//   return View("Index", new DataTableViewModel { ... });
//   ...
//   <partial name="Components/_DataTable" model="Model.Table" />
// ================================================================
using System.Collections.Generic;

namespace HRManagementSystem.Web.ViewModels
{
    public class DataTableColumn
    {
        // Dictionary key used to pull the cell value out of each row.
        public string Key { get; set; } = "";
        // Column header text.
        public string Label { get; set; } = "";
        // Enables the sortable header affordance + client-side sort for this column.
        public bool Sortable { get; set; } = false;
        // Optional: right-align numeric/status columns.
        public bool AlignEnd { get; set; } = false;
    }

    public class DataTableRowAction
    {
        // Machine key dispatched back to the page via the dt:action event, e.g. "edit".
        public string Action { get; set; } = "";
        // Label shown in the row's actions dropdown, e.g. "Edit".
        public string Label { get; set; } = "";
        // Adds text-danger styling for destructive actions (Delete, Disable, Reject...).
        public bool Destructive { get; set; } = false;
    }

    public class DataTableRow
    {
        // Stable identifier for this row (employee id, requisition id, etc.)
        // returned in the dt:action event so the page knows what was clicked.
        public string Id { get; set; } = "";
        // Cell HTML/text keyed by column Key. Pre-render badges/pills/avatars here
        // in the controller or a view helper before assigning to the model.
        public Dictionary<string, string> Cells { get; set; } = new();
        // Optional raw values used for sorting when the display cell isn't
        // directly sortable (e.g. a formatted date string). Falls back to Cells.
        public Dictionary<string, string>? SortValues { get; set; }
    }

    public class DataTableViewModel
    {
        // Unique id for this table instance; required when a page renders more than one.
        public string Id { get; set; } = "dataTable";
        public List<DataTableColumn> Columns { get; set; } = new();
        public List<DataTableRow> Rows { get; set; } = new();
        public List<DataTableRowAction> RowActions { get; set; } = new();

        public bool ShowSearch { get; set; } = true;
        public string SearchPlaceholder { get; set; } = "Search...";
        public bool ShowExport { get; set; } = true;
        public int PageSize { get; set; } = 10;

        public string EmptyIcon { get; set; } = "inbox";
        public string EmptyMessage { get; set; } = "No records found.";

        // Optional extra filter dropdowns rendered before the search box is disabled;
        // consuming views typically render their own <select> filters in the
        // FilterToolbar section and wire them to fire a "dt:refilter" event instead,
        // since filter fields vary per module (department, status, role, etc.).
    }
}