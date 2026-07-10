document.addEventListener("DOMContentLoaded", function () {
  const users = [
    { id: 1, name: "Robert Fox", email: "robert.fox@enterprise.com", role: "HR Manager", roleCls: "role-hr", linked: "Robert Fox", status: "Active", lastLogin: "2026-07-09T08:42:00", avatar: "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=100&auto=format&fit=crop&q=60" },
    { id: 2, name: "Kristin Watson", email: "kristin.watson@enterprise.com", role: "Admin", roleCls: "role-admin", linked: "—", status: "Active", lastLogin: "2026-07-09T07:58:00", avatar: "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100&auto=format&fit=crop&q=60" },
    { id: 3, name: "David Kim", email: "david.kim@enterprise.com", role: "Payroll Admin", roleCls: "role-payroll", linked: "David Kim", status: "Active", lastLogin: "2026-07-08T17:20:00", avatar: "https://images.unsplash.com/photo-1560250097-0b93528c311a?w=100&auto=format&fit=crop&q=60" },
    { id: 4, name: "Guy Hawkins", email: "guy.hawkins@enterprise.com", role: "Hiring Manager", roleCls: "role-hiring", linked: "Guy Hawkins", status: "Disabled", lastLogin: "2026-06-21T11:05:00", avatar: "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100&auto=format&fit=crop&q=60" },
    { id: 5, name: "Jane Cooper", email: "jane.cooper@enterprise.com", role: "Employee", roleCls: "role-employee", linked: "Jane Cooper", status: "Active", lastLogin: "2026-07-09T09:02:00", avatar: "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=100&auto=format&fit=crop&q=60" },
    { id: 6, name: "Arlene McCoy", email: "arlene.mccoy@enterprise.com", role: "HR Manager", roleCls: "role-hr", linked: "Arlene McCoy", status: "Invited", lastLogin: null, avatar: "https://images.unsplash.com/photo-1487412720507-e7ab37603c6f?w=100&auto=format&fit=crop&q=60" },
    { id: 7, name: "Cody Fisher", email: "cody.fisher@enterprise.com", role: "Employee", roleCls: "role-employee", linked: "Cody Fisher", status: "Active", lastLogin: "2026-07-07T14:12:00", avatar: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=100&auto=format&fit=crop&q=60" },
  ];

  const body = document.getElementById("userBody");
  const searchInput = document.getElementById("userSearch");
  const roleFilter = document.getElementById("userRole");
  const statusFilter = document.getElementById("userStatus");
  const clearBtn = document.getElementById("userClear");
  const paginationInfo = document.getElementById("userPaginationInfo");

  let sortKey = null;
  let sortDir = 1;

  const statusClass = (s) =>
    ({
      Active: "account-status-active",
      Disabled: "account-status-disabled",
      Invited: "account-status-invited",
    }[s] || "account-status-active");

  function formatLastLogin(iso) {
    if (!iso) return "Never signed in";
    const d = new Date(iso);
    return d.toLocaleDateString("en-US", { month: "short", day: "numeric", year: "numeric" }) + " · " + d.toLocaleTimeString("en-US", { hour: "2-digit", minute: "2-digit" });
  }

  function render(list) {
    if (!list.length) {
      body.innerHTML = `
        <tr><td colspan="7">
          <div class="empty-state">
            <span class="material-symbols-outlined">manage_accounts</span>
            <p>No users match your search or filters.</p>
          </div>
        </td></tr>`;
      paginationInfo.textContent = `Showing 0 of ${users.length} users`;
      return;
    }

    body.innerHTML = list
      .map(
        (u) => `
      <tr>
        <td class="ps-4">
          <div class="emp">
            <img class="row-avatar" src="${u.avatar}" alt="${u.name}">
            <div class="fw-semibold" style="color:var(--text)">${u.name}</div>
          </div>
        </td>
        <td class="text-muted">${u.email}</td>
        <td><span class="role-badge ${u.roleCls}">${u.role}</span></td>
        <td>${u.linked}</td>
        <td><span class="badge-status ${statusClass(u.status)}">${u.status}</span></td>
        <td class="text-muted">${formatLastLogin(u.lastLogin)}</td>
        <td class="text-end pe-4">
          <div class="dropdown">
            <button class="icon-btn" data-bs-toggle="dropdown" aria-expanded="false">
              <span class="material-symbols-outlined" style="font-size: 20px">more_vert</span>
            </button>
            <ul class="dropdown-menu dropdown-menu-end">
              <li><a class="dropdown-item" href="#" data-action="edit" data-id="${u.id}">Edit</a></li>
              <li><a class="dropdown-item" href="#" data-action="reset" data-id="${u.id}">Reset password</a></li>
              <li><a class="dropdown-item text-danger" href="#" data-action="disable" data-id="${u.id}">${u.status === "Disabled" ? "Enable account" : "Disable account"}</a></li>
            </ul>
          </div>
        </td>
      </tr>`
      )
      .join("");

    paginationInfo.textContent = `Showing ${list.length} of ${users.length} users`;

    body.querySelectorAll("[data-action]").forEach((el) => {
      el.addEventListener("click", (e) => {
        e.preventDefault();
        const u = users.find((x) => x.id === Number(el.dataset.id));
        if (el.dataset.action === "edit") {
          alert(`Opening edit form for ${u.name}.`);
          return;
        }
        openConfirm(u, el.dataset.action);
      });
    });
  }

  function getFiltered() {
    const q = searchInput.value.toLowerCase().trim();
    const role = roleFilter.value;
    const status = statusFilter.value;

    let filtered = users.filter((u) => {
      if (q && !u.name.toLowerCase().includes(q) && !u.email.toLowerCase().includes(q)) return false;
      if (role && u.role !== role) return false;
      if (status && u.status !== status) return false;
      return true;
    });

    if (sortKey) {
      filtered = filtered.slice().sort((a, b) => {
        const va = sortKey === "lastLoginSort" ? a.lastLogin || "" : a[sortKey];
        const vb = sortKey === "lastLoginSort" ? b.lastLogin || "" : b[sortKey];
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

  [searchInput, roleFilter, statusFilter].forEach((el) => el.addEventListener("input", applyFilters));
  clearBtn.addEventListener("click", () => {
    searchInput.value = "";
    roleFilter.value = "";
    statusFilter.value = "";
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

  // Confirmation modal
  const confirmModalEl = document.getElementById("userConfirmModal");
  const confirmModal = new bootstrap.Modal(confirmModalEl);
  const confirmTitle = document.getElementById("userConfirmTitle");
  const confirmBody = document.getElementById("userConfirmBody");
  const confirmBtn = document.getElementById("userConfirmBtn");
  let pending = null;

  function openConfirm(user, action) {
    pending = { user, action };
    if (action === "reset") {
      confirmTitle.textContent = "Reset password";
      confirmBody.textContent = `Send a password reset email to ${user.name} (${user.email})?`;
      confirmBtn.className = "btn btn-primary btn-sm";
      confirmBtn.textContent = "Send Reset Link";
    } else {
      const enabling = user.status === "Disabled";
      confirmTitle.textContent = enabling ? "Enable account" : "Disable account";
      confirmBody.textContent = enabling
        ? `Re-enable access for ${user.name}? They'll be able to sign in again immediately.`
        : `Disable access for ${user.name}? They won't be able to sign in until re-enabled.`;
      confirmBtn.className = enabling ? "btn btn-primary btn-sm" : "btn btn-danger btn-sm";
      confirmBtn.textContent = enabling ? "Enable Account" : "Disable Account";
    }
    confirmModal.show();
  }

  confirmBtn.addEventListener("click", () => {
    if (!pending) return;
    const { user, action } = pending;
    if (action === "disable") {
      user.status = user.status === "Disabled" ? "Active" : "Disabled";
      applyFilters();
    } else {
      alert(`Password reset link sent to ${user.email}.`);
    }
    confirmModal.hide();
    pending = null;
  });

  document.getElementById("createUserBtn").addEventListener("click", () => {
    new bootstrap.Modal(document.getElementById("createUserModal")).show();
  });
  document.getElementById("createUserConfirmBtn").addEventListener("click", () => {
    bootstrap.Modal.getInstance(document.getElementById("createUserModal")).hide();
    alert("Invite sent. The new user will receive an email to set up their account.");
  });

  render(users);
});
