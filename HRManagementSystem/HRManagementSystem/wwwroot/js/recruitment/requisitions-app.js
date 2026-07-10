document.addEventListener("DOMContentLoaded", function () {
  const requisitions = [
    { title: "Senior Full Stack Developer", dept: "Engineering", requestedBy: "Robert Fox", headcount: 2, status: "Open", applicants: 34, created: "2026-06-18" },
    { title: "DevOps Engineer", dept: "Engineering", requestedBy: "Robert Fox", headcount: 1, status: "Open", applicants: 21, created: "2026-06-22" },
    { title: "Enterprise Account Executive", dept: "Sales", requestedBy: "Guy Hawkins", headcount: 3, status: "Open", applicants: 58, created: "2026-06-10" },
    { title: "Marketing Analyst", dept: "Marketing", requestedBy: "Kristin Watson", headcount: 1, status: "Pending Approval", applicants: 0, created: "2026-07-02" },
    { title: "Payroll Specialist", dept: "Finance", requestedBy: "David Kim", headcount: 1, status: "On Hold", applicants: 12, created: "2026-05-29" },
    { title: "HR Business Partner", dept: "Human Resources", requestedBy: "Arlene McCoy", headcount: 1, status: "Open", applicants: 9, created: "2026-06-30" },
    { title: "Product Designer", dept: "Product Design", requestedBy: "Jacob Jones", headcount: 2, status: "Closed", applicants: 47, created: "2026-04-15" },
    { title: "QA Specialist", dept: "Engineering", requestedBy: "Robert Fox", headcount: 1, status: "Open", applicants: 16, created: "2026-06-25" },
  ];

  const body = document.getElementById("reqBody");
  const searchInput = document.getElementById("reqSearch");
  const deptFilter = document.getElementById("reqDept");
  const statusFilter = document.getElementById("reqStatus");
  const dateFrom = document.getElementById("reqDateFrom");
  const dateTo = document.getElementById("reqDateTo");
  const clearBtn = document.getElementById("reqClear");
  const paginationInfo = document.getElementById("reqPaginationInfo");

  const statusChip = (s) =>
    ({
      Open: "chip-success",
      "On Hold": "chip-warning",
      Closed: "chip-danger",
      "Pending Approval": "chip-primary",
    }[s] || "chip-primary");

  function formatDate(iso) {
    return new Date(iso + "T00:00:00").toLocaleDateString("en-US", { month: "short", day: "numeric", year: "numeric" });
  }

  function render(list) {
    if (!list.length) {
      body.innerHTML = `
        <tr><td colspan="8">
          <div class="empty-state">
            <span class="material-symbols-outlined">work_off</span>
            <p>No requisitions match your filters.</p>
          </div>
        </td></tr>`;
      paginationInfo.textContent = `Showing 0 of ${requisitions.length} requisitions`;
      return;
    }

    body.innerHTML = list
      .map(
        (r, i) => `
      <tr>
        <td class="ps-4 fw-semibold" style="color:var(--text)">${r.title}</td>
        <td>${r.dept}</td>
        <td>${r.requestedBy}</td>
        <td>${r.headcount}</td>
        <td><span class="chip ${statusChip(r.status)}">${r.status}</span></td>
        <td>${r.applicants}</td>
        <td class="text-muted">${formatDate(r.created)}</td>
        <td class="text-end pe-4">
          <div class="dropdown">
            <button class="icon-btn" data-bs-toggle="dropdown" aria-expanded="false">
              <span class="material-symbols-outlined" style="font-size: 20px">more_vert</span>
            </button>
            <ul class="dropdown-menu dropdown-menu-end">
              <li><a class="dropdown-item" href="#" data-action="view" data-idx="${i}">View</a></li>
              <li><a class="dropdown-item" href="#" data-action="edit" data-idx="${i}">Edit</a></li>
              <li><a class="dropdown-item" href="#" data-action="open" data-idx="${i}">Open position</a></li>
              <li><a class="dropdown-item text-danger" href="#" data-action="close" data-idx="${i}">Close position</a></li>
            </ul>
          </div>
        </td>
      </tr>`
      )
      .join("");

    paginationInfo.textContent = `Showing ${list.length} of ${requisitions.length} requisitions`;

    body.querySelectorAll("[data-action]").forEach((el) => {
      el.addEventListener("click", (e) => {
        e.preventDefault();
        const r = list[Number(el.dataset.idx)];
        const actions = {
          view: () => alert(`Viewing requisition: ${r.title}`),
          edit: () => alert(`Opening edit form for: ${r.title}`),
          open: () => alert(`${r.title} marked as Open.`),
          close: () => alert(`${r.title} marked as Closed.`),
        };
        actions[el.dataset.action]?.();
      });
    });
  }

  function applyFilters() {
    const q = searchInput.value.toLowerCase().trim();
    const dept = deptFilter.value;
    const status = statusFilter.value;
    const from = dateFrom.value;
    const to = dateTo.value;

    const filtered = requisitions.filter((r) => {
      if (q && !r.title.toLowerCase().includes(q)) return false;
      if (dept && r.dept !== dept) return false;
      if (status && r.status !== status) return false;
      if (from && r.created < from) return false;
      if (to && r.created > to) return false;
      return true;
    });
    render(filtered);
  }

  [searchInput, deptFilter, statusFilter, dateFrom, dateTo].forEach((el) =>
    el.addEventListener("input", applyFilters)
  );

  clearBtn.addEventListener("click", () => {
    searchInput.value = "";
    deptFilter.value = "";
    statusFilter.value = "";
    dateFrom.value = "";
    dateTo.value = "";
    applyFilters();
  });

  document.getElementById("createReqBtn").addEventListener("click", () => {
    alert("Open the new requisition wizard.");
  });

  render(requisitions);
});
