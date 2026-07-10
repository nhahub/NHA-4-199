document.addEventListener("DOMContentLoaded", function () {
  const candidates = [
    { name: "Elena Gilbert", email: "elena.gilbert@mail.com", position: "Senior Full Stack Developer", dept: "Engineering", stage: "Applied", applied: "2026-07-05", rating: 3, avatar: "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=100&auto=format&fit=crop&q=60" },
    { name: "Chloe Sullivan", email: "chloe.sullivan@mail.com", position: "DevOps Engineer", dept: "Engineering", stage: "Screening", applied: "2026-07-02", rating: 4, avatar: "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=100&auto=format&fit=crop&q=60" },
    { name: "Jack Shephard", email: "jack.shephard@mail.com", position: "DevOps Engineer", dept: "Engineering", stage: "Interview", applied: "2026-06-28", rating: 5, avatar: "https://images.unsplash.com/photo-1560250097-0b93528c311a?w=100&auto=format&fit=crop&q=60" },
    { name: "Kate Austen", email: "kate.austen@mail.com", position: "Enterprise Account Executive", dept: "Sales", stage: "Offer", applied: "2026-06-20", rating: 4, avatar: "https://images.unsplash.com/photo-1502685104226-ee32379fefbe?w=100&auto=format&fit=crop&q=60" },
    { name: "Sawyer Ford", email: "sawyer.ford@mail.com", position: "Product Designer", dept: "Product Design", stage: "Hired", applied: "2026-05-30", rating: 5, avatar: "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&auto=format&fit=crop&q=60" },
    { name: "Sarah Connor", email: "sarah.connor@mail.com", position: "QA Specialist", dept: "Engineering", stage: "Rejected", applied: "2026-06-15", rating: 2, avatar: "https://images.unsplash.com/photo-1489424731084-a5d8b219a5bb?w=100&auto=format&fit=crop&q=60" },
    { name: "Marcus Wright", email: "marcus.wright@mail.com", position: "Senior Full Stack Developer", dept: "Engineering", stage: "Interview", applied: "2026-07-01", rating: 4, avatar: "https://images.unsplash.com/photo-1519345182560-3f2917c472ef?w=100&auto=format&fit=crop&q=60" },
  ];

  const body = document.getElementById("appBody");
  const searchInput = document.getElementById("appSearch");
  const positionFilter = document.getElementById("appPosition");
  const stageFilter = document.getElementById("appStage");
  const dateFilter = document.getElementById("appDate");
  const ratingFilter = document.getElementById("appRating");
  const clearBtn = document.getElementById("appClear");
  const paginationInfo = document.getElementById("appPaginationInfo");

  let sortKey = null;
  let sortDir = 1;

  const stageClass = (s) => `stage-${s.toLowerCase()}`;

  function formatDate(iso) {
    return new Date(iso + "T00:00:00").toLocaleDateString("en-US", { month: "short", day: "numeric", year: "numeric" });
  }

  function stars(n) {
    return Array.from({ length: 5 }, (_, i) => `<span class="material-symbols-outlined ${i < n ? "filled" : ""}">star</span>`).join("");
  }

  function renderSkeleton() {
    body.innerHTML = Array.from({ length: 5 })
      .map(
        () => `
      <tr>
        <td class="ps-4"><span class="skeleton-bar" style="width:140px"></span></td>
        <td><span class="skeleton-bar" style="width:160px"></span></td>
        <td><span class="skeleton-bar" style="width:90px"></span></td>
        <td><span class="skeleton-bar" style="width:70px"></span></td>
        <td><span class="skeleton-bar" style="width:80px"></span></td>
        <td><span class="skeleton-bar" style="width:70px"></span></td>
        <td class="text-end pe-4"><span class="skeleton-bar" style="width:24px"></span></td>
      </tr>`
      )
      .join("");
  }

  function render(list) {
    if (!list.length) {
      body.innerHTML = `
        <tr><td colspan="7">
          <div class="empty-state">
            <span class="material-symbols-outlined">person_search</span>
            <p>No candidates match your search or filters.</p>
          </div>
        </td></tr>`;
      paginationInfo.textContent = `Showing 0 of ${candidates.length} candidates`;
      return;
    }

    body.innerHTML = list
      .map(
        (c, i) => `
      <tr>
        <td class="ps-4">
          <div class="emp">
            <img class="row-avatar" src="${c.avatar}" alt="${c.name}">
            <div>
              <div class="fw-semibold" style="color:var(--text)">${c.name}</div>
              <div class="text-muted small">${c.email}</div>
            </div>
          </div>
        </td>
        <td>${c.position}</td>
        <td>${c.dept}</td>
        <td><span class="stage-pill ${stageClass(c.stage)}">${c.stage}</span></td>
        <td class="text-muted">${formatDate(c.applied)}</td>
        <td><span class="star-rating">${stars(c.rating)}</span></td>
        <td class="text-end pe-4">
          <div class="dropdown">
            <button class="icon-btn" data-bs-toggle="dropdown" aria-expanded="false">
              <span class="material-symbols-outlined" style="font-size: 20px">more_vert</span>
            </button>
            <ul class="dropdown-menu dropdown-menu-end">
              <li><a class="dropdown-item" href="candidate-details.html?${new URLSearchParams({ name: c.name, position: c.position, stage: c.stage, applied: c.applied, email: c.email, avatar: c.avatar })}">View profile</a></li>
              <li><a class="dropdown-item" href="#" data-action="move" data-idx="${i}">Move stage</a></li>
              <li><a class="dropdown-item" href="interviews.html">Schedule interview</a></li>
              <li><a class="dropdown-item text-danger" href="#" data-action="reject" data-idx="${i}">Reject candidate</a></li>
            </ul>
          </div>
        </td>
      </tr>`
      )
      .join("");

    paginationInfo.textContent = `Showing ${list.length} of ${candidates.length} candidates`;

    body.querySelectorAll("[data-action]").forEach((el) => {
      el.addEventListener("click", (e) => {
        e.preventDefault();
        const c = list[Number(el.dataset.idx)];
        if (el.dataset.action === "move") alert(`Move ${c.name} to the next stage.`);
        if (el.dataset.action === "reject") alert(`${c.name} marked as rejected.`);
      });
    });
  }

  function getFiltered() {
    const q = searchInput.value.toLowerCase().trim();
    const position = positionFilter.value;
    const stage = stageFilter.value;
    const date = dateFilter.value;
    const minRating = Number(ratingFilter.value);

    let filtered = candidates.filter((c) => {
      if (q && !c.name.toLowerCase().includes(q) && !c.email.toLowerCase().includes(q)) return false;
      if (position && c.position !== position) return false;
      if (stage && c.stage !== stage) return false;
      if (date && c.applied !== date) return false;
      if (minRating && c.rating < minRating) return false;
      return true;
    });

    if (sortKey) {
      filtered = filtered.slice().sort((a, b) => {
        const va = a[sortKey];
        const vb = b[sortKey];
        if (va < vb) return -1 * sortDir;
        if (va > vb) return 1 * sortDir;
        return 0;
      });
    }
    return filtered;
  }

  function applyFilters() {
    render(getFiltered());
  }

  [searchInput, positionFilter, stageFilter, dateFilter, ratingFilter].forEach((el) =>
    el.addEventListener("input", applyFilters)
  );

  clearBtn.addEventListener("click", () => {
    searchInput.value = "";
    positionFilter.value = "";
    stageFilter.value = "";
    dateFilter.value = "";
    ratingFilter.value = "0";
    applyFilters();
  });

  document.querySelectorAll(".sortable").forEach((el) => {
    el.addEventListener("click", () => {
      const key = el.dataset.sort;
      if (sortKey === key) {
        sortDir *= -1;
      } else {
        sortKey = key;
        sortDir = 1;
      }
      document.querySelectorAll(".sortable").forEach((s) => s.classList.remove("sort-active"));
      el.classList.add("sort-active");
      applyFilters();
    });
  });

  // Simulate an initial load state, matching how the live ATS fetches candidates.
  renderSkeleton();
  setTimeout(applyFilters, 500);
});
