document.addEventListener("DOMContentLoaded", function () {
  let shifts = [
    { id: 1, name: "General Shift", start: "09:00", end: "18:00", late: 15, halfDay: 4, active: true },
    { id: 2, name: "Flexible Shift", start: "10:00", end: "19:00", late: 20, halfDay: 4, active: true },
    { id: 3, name: "Early Shift", start: "07:00", end: "16:00", late: 10, halfDay: 4, active: true },
    { id: 4, name: "Night Shift", start: "22:00", end: "06:00", late: 15, halfDay: 4, active: false },
  ];
  let nextId = 5;

  const body = document.getElementById("shiftBody");

  function formatTime(t) {
    const [h, m] = t.split(":").map(Number);
    const period = h >= 12 ? "PM" : "AM";
    const hour = ((h + 11) % 12) + 1;
    return `${hour}:${String(m).padStart(2, "0")} ${period}`;
  }

  function render() {
    if (!shifts.length) {
      body.innerHTML = `
        <tr><td colspan="7">
          <div class="empty-state">
            <span class="material-symbols-outlined">schedule</span>
            <p>No shifts configured yet.</p>
          </div>
        </td></tr>`;
      return;
    }
    body.innerHTML = shifts
      .map(
        (s) => `
      <tr>
        <td class="ps-4 fw-semibold" style="color:var(--text)"><span class="shift-color-dot"></span>${s.name}</td>
        <td>${formatTime(s.start)}</td>
        <td>${formatTime(s.end)}</td>
        <td>${s.late} min</td>
        <td>${s.halfDay} hrs</td>
        <td><span class="chip ${s.active ? "chip-success" : "chip-danger"}">${s.active ? "Active" : "Inactive"}</span></td>
        <td class="text-end pe-4">
          <div class="d-flex justify-content-end gap-1">
            <button class="icon-btn" data-action="edit" data-id="${s.id}" title="Edit"><span class="material-symbols-outlined" style="font-size:18px">edit</span></button>
            <button class="icon-btn" data-action="delete" data-id="${s.id}" title="Delete"><span class="material-symbols-outlined" style="font-size:18px">delete</span></button>
          </div>
        </td>
      </tr>`
      )
      .join("");

    body.querySelectorAll("[data-action]").forEach((btn) => {
      btn.addEventListener("click", () => {
        const shift = shifts.find((x) => x.id === Number(btn.dataset.id));
        if (btn.dataset.action === "edit") openModal(shift);
        else {
          if (confirm(`Remove "${shift.name}"? Employees assigned to this shift will need to be reassigned.`)) {
            shifts = shifts.filter((x) => x.id !== shift.id);
            render();
          }
        }
      });
    });
  }

  // Modal
  const modalEl = document.getElementById("shiftModal");
  const modal = new bootstrap.Modal(modalEl);
  const modalTitle = document.getElementById("shiftModalTitle");
  const form = document.getElementById("shiftForm");
  const idInput = document.getElementById("shiftId");
  const nameInput = document.getElementById("shiftName");
  const startInput = document.getElementById("shiftStart");
  const endInput = document.getElementById("shiftEnd");
  const lateInput = document.getElementById("lateThreshold");
  const halfDayInput = document.getElementById("halfDayThreshold");
  const activeInput = document.getElementById("shiftActive");

  function openModal(shift) {
    if (shift) {
      modalTitle.textContent = "Edit Shift";
      idInput.value = shift.id;
      nameInput.value = shift.name;
      startInput.value = shift.start;
      endInput.value = shift.end;
      lateInput.value = shift.late;
      halfDayInput.value = shift.halfDay;
      activeInput.checked = shift.active;
    } else {
      modalTitle.textContent = "Add Shift";
      form.reset();
      idInput.value = "";
      activeInput.checked = true;
    }
    modal.show();
  }

  document.getElementById("addShiftBtn").addEventListener("click", () => openModal(null));

  form.addEventListener("submit", (e) => {
    e.preventDefault();
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const data = {
      name: nameInput.value.trim(),
      start: startInput.value,
      end: endInput.value,
      late: Number(lateInput.value),
      halfDay: Number(halfDayInput.value),
      active: activeInput.checked,
    };

    if (idInput.value) {
      const shift = shifts.find((x) => x.id === Number(idInput.value));
      Object.assign(shift, data);
    } else {
      shifts.push({ id: nextId++, ...data });
    }
    modal.hide();
    render();
  });

  render();
});
