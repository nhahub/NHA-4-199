document.addEventListener("DOMContentLoaded", function () {
  const requests = [
    { id: 1, name: "Sarah Jenkins", dept: "Marketing", type: "Annual", typeCls: "leave-annual", start: "2026-07-12", end: "2026-07-14", days: 3, managerDecision: "Pending", status: "Pending" },
    { id: 2, name: "David Kim", dept: "Finance", type: "Sick", typeCls: "leave-sick", start: "2026-07-09", end: "2026-07-09", days: 1, managerDecision: "Approved", status: "Approved" },
    { id: 3, name: "Amanda Foster", dept: "HR & Ops", type: "Casual", typeCls: "leave-casual", start: "2026-07-08", end: "2026-07-08", days: 1, managerDecision: "Approved", status: "Approved" },
    { id: 4, name: "Cody Fisher", dept: "Product Design", type: "Unpaid", typeCls: "leave-unpaid", start: "2026-07-21", end: "2026-07-25", days: 5, managerDecision: "Pending", status: "Pending" },
    { id: 5, name: "Elena Rodriguez", dept: "Sales", type: "Parental", typeCls: "leave-parental", start: "2026-08-01", end: "2026-09-12", days: 42, managerDecision: "Rejected", status: "Rejected" },
    { id: 6, name: "Michael Chang", dept: "Engineering", type: "Annual", typeCls: "leave-annual", start: "2026-07-18", end: "2026-07-19", days: 2, managerDecision: "Pending", status: "Pending" },
    { id: 7, name: "Jane Cooper", dept: "Engineering", type: "Sick", typeCls: "leave-sick", start: "2026-07-06", end: "2026-07-07", days: 2, managerDecision: "Approved", status: "Approved" },
    { id: 8, name: "Guy Hawkins", dept: "Sales", type: "Casual", typeCls: "leave-casual", start: "2026-07-15", end: "2026-07-15", days: 1, managerDecision: "Pending", status: "Pending" },
  ];

  const body = document.getElementById("lrBody");
  const searchInput = document.getElementById("lrSearch");
  const typeFilter = document.getElementById("lrType");
  const statusFilter = document.getElementById("lrStatus");
  const dateFrom = document.getElementById("lrDateFrom");
  const dateTo = document.getElementById("lrDateTo");
  const clearBtn = document.getElementById("lrClear");
  const paginationInfo = document.getElementById("lrPaginationInfo");

  const statusChip = (s) => ({ Pending: "chip-warning", Approved: "chip-success", Rejected: "chip-danger" }[s] || "chip-primary");

  function formatDate(iso) {
    return new Date(iso + "T00:00:00").toLocaleDateString("en-US", { month: "short", day: "numeric", year: "numeric" });
  }

  function decisionCell(r) {
    if (r.managerDecision === "Pending") return `<span class="decision-pending">Awaiting review</span>`;
    return `<span class="chip ${statusChip(r.managerDecision)}">${r.managerDecision}</span>`;
  }

  function render(list) {
    if (!list.length) {
      body.innerHTML = `
        <tr><td colspan="9">
          <div class="empty-state">
            <span class="material-symbols-outlined">fact_check</span>
            <p>No leave requests match your filters.</p>
          </div>
        </td></tr>`;
      paginationInfo.textContent = `Showing 0 of ${requests.length} requests`;
      return;
    }

    body.innerHTML = list
      .map(
        (r) => `
      <tr>
        <td class="ps-4 fw-semibold" style="color:var(--text)">${r.name}</td>
        <td>${r.dept}</td>
        <td><span class="leave-type-pill ${r.typeCls}">${r.type}</span></td>
        <td class="text-muted">${formatDate(r.start)}</td>
        <td class="text-muted">${formatDate(r.end)}</td>
        <td>${r.days}</td>
        <td>${decisionCell(r)}</td>
        <td><span class="chip ${statusChip(r.status)}">${r.status}</span></td>
        <td class="text-end pe-4">
          <div class="d-flex justify-content-end gap-1">
            <button class="btn btn-outline-secondary btn-sm" data-action="view" data-id="${r.id}">View</button>
            <button class="btn btn-success btn-sm" data-action="approve" data-id="${r.id}" ${r.status !== "Pending" ? "disabled" : ""}>Approve</button>
            <button class="btn btn-outline-danger btn-sm" data-action="reject" data-id="${r.id}" ${r.status !== "Pending" ? "disabled" : ""}>Reject</button>
          </div>
        </td>
      </tr>`
      )
      .join("");

    paginationInfo.textContent = `Showing ${list.length} of ${requests.length} requests`;

    body.querySelectorAll("[data-action]").forEach((btn) => {
      btn.addEventListener("click", () => {
        const r = requests.find((x) => x.id === Number(btn.dataset.id));
        if (btn.dataset.action === "view") {
          alert(`${r.name} · ${r.type} leave · ${formatDate(r.start)} - ${formatDate(r.end)} (${r.days} day${r.days > 1 ? "s" : ""})`);
          return;
        }
        openDecisionModal(r, btn.dataset.action);
      });
    });
  }

  function getFiltered() {
    const q = searchInput.value.toLowerCase().trim();
    const type = typeFilter.value;
    const status = statusFilter.value;
    const from = dateFrom.value;
    const to = dateTo.value;

    return requests.filter((r) => {
      if (q && !r.name.toLowerCase().includes(q)) return false;
      if (type && r.type !== type) return false;
      if (status && r.status !== status) return false;
      if (from && r.start < from) return false;
      if (to && r.end > to) return false;
      return true;
    });
  }

  function applyFilters() {
    render(getFiltered());
  }

  [searchInput, typeFilter, statusFilter, dateFrom, dateTo].forEach((el) => el.addEventListener("input", applyFilters));

  clearBtn.addEventListener("click", () => {
    searchInput.value = "";
    typeFilter.value = "";
    statusFilter.value = "";
    dateFrom.value = "";
    dateTo.value = "";
    applyFilters();
  });

  // Decision modal
  const modalEl = document.getElementById("decisionModal");
  const modal = new bootstrap.Modal(modalEl);
  const modalTitle = document.getElementById("decisionModalTitle");
  const modalBody = document.getElementById("decisionModalBody");
  const decisionNote = document.getElementById("decisionNote");
  const confirmBtn = document.getElementById("decisionConfirmBtn");
  let pending = null;

  function openDecisionModal(request, action) {
    pending = { request, action };
    decisionNote.value = "";
    if (action === "approve") {
      modalTitle.textContent = "Approve leave request";
      modalBody.textContent = `Approve ${request.name}'s ${request.type.toLowerCase()} leave request for ${request.days} day${request.days > 1 ? "s" : ""}?`;
      confirmBtn.className = "btn btn-success btn-sm";
      confirmBtn.textContent = "Approve";
    } else {
      modalTitle.textContent = "Reject leave request";
      modalBody.textContent = `Reject ${request.name}'s ${request.type.toLowerCase()} leave request for ${request.days} day${request.days > 1 ? "s" : ""}?`;
      confirmBtn.className = "btn btn-danger btn-sm";
      confirmBtn.textContent = "Reject";
    }
    modal.show();
  }

  confirmBtn.addEventListener("click", () => {
    if (!pending) return;
    const { request, action } = pending;
    const newStatus = action === "approve" ? "Approved" : "Rejected";
    request.status = newStatus;
    request.managerDecision = newStatus;
    modal.hide();
    applyFilters();
    pending = null;
  });

  render(requests);
});
