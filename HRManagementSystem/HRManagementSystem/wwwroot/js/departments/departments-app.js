document.addEventListener("DOMContentLoaded", () => {
  const departments = [
    { name: "Engineering", manager: "Robert Fox", title: "Senior Engineering Director", employees: 42, openRoles: 3, status: "active", avatar: "https://lh3.googleusercontent.com/aida-public/AB6AXuAaSv000TzEkavregoCnr-hGcQdnQUAHvlr7bCw7GcQ-vYFjnMYRkjynIt-OQca9efTmuo3hJvsmo3vMdCfvVvy49Z9Lzs0n4p32xZab8Vvsi2ksAv2eRUKJMNVAKO2_TgwR4q9CITvgsiCcDDjOGKg5nWo8ISeDm45dRNVMaJ3yyn_PiLPNdpafE1eAa7We_8ujsYfVsZZyDM-iTn-LMXvUJGdzBK3nvXROIiC4ioi2WlAFiVi1nL7", icon: "engineering" },
    { name: "Marketing", manager: "Kristin Watson", title: "CMO", employees: 28, openRoles: 1, status: "active", avatar: "https://lh3.googleusercontent.com/aida-public/AB6AXuDXJYKPHilJes7OzaXMVj-P4p0aLq7NiWyW3ARwYzTy8bi4XoE-Q-LXWIW2V-Hv3NN0JNHwfSy78Mij7hmhnsoYO8t_OdprDOovxdCjSQ291agT0fXrimug6RY3dqDsodnq3QVr34Hy0M7zX98SgcorQKlBt-ptTRkbzS43rO6CmS4EkvMQq2acliWk92dgO8_rj9X6so2pjbo6Wcyc4ZvZfql6-vji--0RCUuckMl3KCMuGRkZu4Jb", icon: "campaign" },
    { name: "Human Resources", manager: "Arlene McCoy", title: "HR Director", employees: 15, openRoles: 0, status: "active", avatar: "https://lh3.googleusercontent.com/aida-public/AB6AXuCRFsPCI0KQNeZbgP2W4kL-SoF-GoPzVul8Kq98LBphp0CmeYFevvq-5La5YCbpO1foWVOgtg3pD2Jg8tpnhk4uGVIru9H5g25oDTmQn0nkhBqbsUqu1dW1f0Vqqym1W2aLtEK4_oi9ajFGxvSbZC2cxbk0ixlmlKs-z5y1IePoZdju_7cL8lRNxEu6BXBpJu3Jho5I-UE4-32HIrT7wUSrwaV6bSvqhRJvfU8jxzb16jUHI2aiCfAh", icon: "diversity_3" },
    { name: "Sales", manager: "Guy Hawkins", title: "Head of Sales", employees: 56, openRoles: 8, status: "active", avatar: "https://lh3.googleusercontent.com/aida-public/AB6AXuBcPQ81NIdzxHpzMEwMzUtbB2DhH4AbyT9FFhfXHLH6bBWRFq-olBi_FOVNANKixvOwv_p-qxNl97j5BD5vzn7aURIUgYMzZ3SX0hL9Ht7x_lebM2fUlWaFaZVhQ_f8hUuXcreks-xHS3JwjMZJcOkmTQV0pL1U8r9rWMLZt-ZQYZ-Le5k1tKMx2Gao5QLRg4y3XTY5zfQCkVMPOEIBzcitt1AnftEcZjHXjO-fqtD6MhNL_JKI-U0Y", icon: "point_of_sale" },
    { name: "Customer Support", manager: "Eleanor Pena", title: "Operations Lead", employees: 0, openRoles: 0, status: "inactive", avatar: "https://lh3.googleusercontent.com/aida-public/AB6AXuCg6fwkXJpnm5z1Pye7QBiuNtJ-iypvgpBc_M6M86Y2cSAIyGvanuwLpWOUft8WCK2L3_IN6Edwn99BlApbVfg2Jo_EsZqXt9BCnkH5zEYnGCdhkWPV2wkLYj8-RxG0iiEWEBt1VnNHdhxgG9GMiiHO7TXIluYHRKJk1OXPJffC3L4nwrzwhGK4BiphrJmjT_qYNMSIDXj0Ycm7LfXlZV35w_C26oktEVTp905MXTme2I3K5IjIguQi", icon: "support_agent" },
    { name: "Product Design", manager: "Jacob Jones", title: "Design Lead", employees: 12, openRoles: 2, status: "active", avatar: "https://lh3.googleusercontent.com/aida-public/AB6AXuDLZz9j4-bzQTXeu13KhgcLPyC4O1AR1qcDMpGwGGQht1-M8mmUNAF9XklK7GrQLE30l7tii3v6PDfnc4I_hnNrTndSxx_zysoQhcb8RqhswbFgkOP9ThrrV-2YwFMIT692iSYqZAxwq48_6z8NP11ERhuOH9XkTeTmYaJmdVlAHzgqqW9ydiq2Iu0B_qQzaqsoi2MtyIIm5CTMOojXxSAnxUPiDbKdX-SjVB01b96tgwbC_q9Me_uO", icon: "palette" },
  ];

  const grid = document.getElementById("departmentsGrid");
  const searchInput = document.getElementById("deptSearchInput");
  const managerFilter = document.getElementById("managerFilter");
  const statusFilter = document.getElementById("statusFilter");
  const clearFiltersBtn = document.getElementById("clearFiltersBtn");
  const paginationInfo = document.getElementById("paginationInfo");

  function goToDetails(dept) {
    const params = new URLSearchParams({
      name: dept.name,
      manager: dept.manager,
      title: dept.title,
      employees: dept.employees,
      openRoles: dept.openRoles,
      status: dept.status,
      avatar: dept.avatar,
      icon: dept.icon,
    });
    window.location.href = "DepartmentDetails.html?" + params.toString();
  }

  function render(list) {
    if (!list.length) {
      grid.innerHTML = `<div class="col-12"><div class="panel text-center text-muted py-5">No departments found.</div></div>`;
      paginationInfo.textContent = "Showing 0 of " + departments.length + " departments";
      return;
    }

    grid.innerHTML = list
      .map(
        (d, i) => `
      <div class="col-12 col-md-6 col-lg-4">
        <div class="department-card${d.status === "inactive" ? " inactive" : ""}" data-idx="${i}">
          <div class="dept-body">
            <div class="d-flex justify-content-between align-items-start mb-2">
              <h3 class="fw-bold mb-0" style="font-size:16px">${d.name}</h3>
              <span class="chip ${d.status === "active" ? "chip-success" : "chip-warning"} text-uppercase" style="font-size:10px">${d.status}</span>
            </div>
            <div class="d-flex align-items-center gap-2 mt-2">
              <img class="rounded-circle" width="32" height="32" style="object-fit:cover" src="${d.avatar}" alt="${d.manager}" />
              <div>
                <p class="mb-0 small fw-semibold">${d.manager}</p>
                <p class="mb-0 text-muted text-uppercase" style="font-size:10px">${d.title}</p>
              </div>
            </div>
          </div>
          <div class="dept-stats">
            <div>
              <p class="text-muted mb-0 text-uppercase" style="font-size:11px">Employees</p>
              <p class="fw-bold mb-0">${d.employees}</p>
            </div>
            <div>
              <p class="text-muted mb-0 text-uppercase" style="font-size:11px">Open Roles</p>
              <p class="fw-bold mb-0" style="color:var(--primary)">${d.openRoles}</p>
            </div>
          </div>
          <div class="dept-actions">
            <button class="icon-btn action-view" data-idx="${i}" title="View Details">
              <span class="material-symbols-outlined" style="font-size:18px">visibility</span>
            </button>
            <button class="icon-btn action-edit" data-idx="${i}" title="Edit">
              <span class="material-symbols-outlined" style="font-size:18px">edit</span>
            </button>
            <button class="icon-btn action-options" data-idx="${i}" title="Options">
              <span class="material-symbols-outlined" style="font-size:18px">more_vert</span>
            </button>
          </div>
        </div>
      </div>
    `
      )
      .join("");

    paginationInfo.textContent = `Showing ${list.length} of ${departments.length} departments`;

    grid.querySelectorAll(".department-card").forEach((card) => {
      card.addEventListener("click", (e) => {
        if (e.target.closest(".action-edit") || e.target.closest(".action-options")) return;
        const dept = list[Number(card.dataset.idx)];
        goToDetails(dept);
      });
    });
    grid.querySelectorAll(".action-edit").forEach((btn) => {
      btn.addEventListener("click", (e) => {
        e.stopPropagation();
        const dept = list[Number(btn.dataset.idx)];
        alert(`Opening update panel fields for: ${dept.name}`);
      });
    });
    grid.querySelectorAll(".action-options").forEach((btn) => {
      btn.addEventListener("click", (e) => e.stopPropagation());
    });
  }

  function filterDepartments() {
    const q = searchInput.value.toLowerCase().trim();
    const mgr = managerFilter.value;
    const status = statusFilter.value;

    const filtered = departments.filter(
      (d) =>
        d.name.toLowerCase().includes(q) &&
        (mgr === "all" || d.manager === mgr) &&
        (status === "all" || d.status === status)
    );
    render(filtered);
  }

  searchInput.addEventListener("input", filterDepartments);
  managerFilter.addEventListener("change", filterDepartments);
  statusFilter.addEventListener("change", filterDepartments);
  clearFiltersBtn.addEventListener("click", () => {
    searchInput.value = "";
    managerFilter.value = "all";
    statusFilter.value = "all";
    filterDepartments();
  });

  document.getElementById("addDepartmentBtn").addEventListener("click", () => {
    alert("Open configuration wizard to create a new department.");
  });

  render(departments);
});
