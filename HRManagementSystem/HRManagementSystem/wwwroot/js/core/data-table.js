// ================================================================
// wwwroot/js/data-table.js
// Generic client-side engine for Views/Shared/Components/_DataTable.cshtml.
// Works against whatever <tr data-row-id> rows the server already rendered
// into .dt-body — no data fetching here, just search / sort / paginate
// over the DOM, plus a dt:action event so the host page can react to row
// actions (Edit, Delete, Approve...) however it needs to (open a modal,
// call an API, navigate).
// ================================================================
(function () {
  function initTable(tableEl) {
    const pageSize = Number(tableEl.dataset.pageSize) || 10;
    const body = tableEl.querySelector(".dt-body");
    const allRows = Array.from(body.querySelectorAll("tr[data-row-id]"));
    const searchInput = tableEl.querySelector(".dt-search");
    const emptyState = tableEl.querySelector(".dt-empty");
    const tableResponsive = tableEl.querySelector(".table-responsive");
    const paginationInfo = tableEl.querySelector(".dt-pagination-info");
    const pageNumbersEl = tableEl.querySelector(".dt-page-numbers");
    const prevBtn = tableEl.querySelector(".dt-prev");
    const nextBtn = tableEl.querySelector(".dt-next");
    const exportBtn = tableEl.querySelector(".dt-export");

    let sortKey = null;
    let sortDir = 1;
    let currentPage = 1;

    function rowMatchesSearch(row, q) {
      if (!q) return true;
      return row.textContent.toLowerCase().includes(q);
    }

    function getVisibleAfterFilters() {
      const q = (searchInput?.value || "").toLowerCase().trim();
      return allRows.filter((r) => !r.classList.contains("dt-excluded") && rowMatchesSearch(r, q));
    }

    function sortRows(rows) {
      if (!sortKey) return rows;
      return rows.slice().sort((a, b) => {
        const cellA = a.querySelector(`td[data-sort-value]:nth-child(${colIndex(sortKey) + 1})`);
        const cellB = b.querySelector(`td[data-sort-value]:nth-child(${colIndex(sortKey) + 1})`);
        const va = cellA ? cellA.dataset.sortValue : "";
        const vb = cellB ? cellB.dataset.sortValue : "";
        const na = Number(va);
        const nb = Number(vb);
        const bothNumeric = !isNaN(na) && !isNaN(nb) && va !== "" && vb !== "";
        if (bothNumeric) return (na - nb) * sortDir;
        return va.localeCompare(vb) * sortDir;
      });
    }

    function colIndex(key) {
      const headers = Array.from(tableEl.querySelectorAll("thead th"));
      return headers.findIndex((th) => th.querySelector(`[data-sort-key="${key}"]`));
    }

    function render() {
      const filtered = sortRows(getVisibleAfterFilters());
      const totalPages = Math.max(1, Math.ceil(filtered.length / pageSize));
      if (currentPage > totalPages) currentPage = totalPages;

      allRows.forEach((r) => (r.style.display = "none"));

      const start = (currentPage - 1) * pageSize;
      const pageRows = filtered.slice(start, start + pageSize);
      pageRows.forEach((r) => (r.style.display = ""));

      if (emptyState) emptyState.classList.toggle("d-none", filtered.length > 0);
      if (tableResponsive) tableResponsive.classList.toggle("d-none", filtered.length === 0);

      if (paginationInfo) {
        paginationInfo.textContent = filtered.length
          ? `Showing ${start + 1}-${Math.min(start + pageRows.length, filtered.length)} of ${filtered.length} records`
          : `Showing 0 of ${allRows.length} records`;
      }

      if (pageNumbersEl) {
        pageNumbersEl.innerHTML = "";
        for (let p = 1; p <= totalPages; p++) {
          const btn = document.createElement("button");
          btn.className = p === currentPage ? "btn btn-primary btn-sm px-2 py-1" : "btn btn-light btn-sm px-2 py-1 border text-secondary";
          btn.style.fontSize = "12px";
          btn.textContent = String(p);
          btn.addEventListener("click", () => {
            currentPage = p;
            render();
          });
          pageNumbersEl.appendChild(btn);
        }
      }
      if (prevBtn) prevBtn.disabled = currentPage <= 1;
      if (nextBtn) nextBtn.disabled = currentPage >= totalPages;
    }

    searchInput?.addEventListener("input", () => {
      currentPage = 1;
      render();
    });

    tableEl.querySelectorAll(".dt-th-sortable").forEach((th) => {
      th.addEventListener("click", () => {
        const key = th.dataset.sortKey;
        if (sortKey === key) sortDir *= -1;
        else {
          sortKey = key;
          sortDir = 1;
        }
        tableEl.querySelectorAll(".dt-th-sortable").forEach((s) => s.classList.remove("sort-active"));
        th.classList.add("sort-active");
        render();
      });
    });

    prevBtn?.addEventListener("click", () => {
      currentPage = Math.max(1, currentPage - 1);
      render();
    });
    nextBtn?.addEventListener("click", () => {
      currentPage += 1;
      render();
    });

    body.addEventListener("click", (e) => {
      const actionEl = e.target.closest("[data-dt-action]");
      if (!actionEl) return;
      e.preventDefault();
      const row = actionEl.closest("tr[data-row-id]");
      tableEl.dispatchEvent(
        new CustomEvent("dt:action", {
          detail: { action: actionEl.dataset.dtAction, rowId: row?.dataset.rowId },
        })
      );
    });

    exportBtn?.addEventListener("click", () => {
      tableEl.dispatchEvent(new CustomEvent("dt:export"));
    });

    // Allows a host page to mark rows excluded (its own filter selects) then
    // ask this engine to recompute paging/search on top of that.
    tableEl.addEventListener("dt:refilter", () => {
      currentPage = 1;
      render();
    });

    render();
  }

  document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll(".dt-wrap").forEach(initTable);
  });
})();
