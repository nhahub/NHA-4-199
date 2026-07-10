document.addEventListener("DOMContentLoaded", function () {
  const AVAILABLE_BALANCE = 18;
  const USED_DAYS = 6;

  const startDate = document.getElementById("startDate");
  const endDate = document.getElementById("endDate");
  const dayCountLabel = document.getElementById("dayCountLabel");
  const balRemaining = document.getElementById("balRemaining");
  const uploadBox = document.getElementById("uploadBox");
  const fileInput = document.getElementById("fileInput");
  const fileNameWrap = document.getElementById("fileNameWrap");
  const form = document.getElementById("leaveForm");

  function dayCount() {
    if (!startDate.value || !endDate.value) return 0;
    const s = new Date(startDate.value + "T00:00:00");
    const e = new Date(endDate.value + "T00:00:00");
    const diff = Math.round((e - s) / 86400000) + 1;
    return diff > 0 ? diff : 0;
  }

  function updateSummary() {
    const days = dayCount();
    if (!startDate.value || !endDate.value) {
      dayCountLabel.textContent = "Select a start and end date to calculate duration.";
      balRemaining.textContent = `${AVAILABLE_BALANCE} days`;
      return;
    }
    if (days <= 0) {
      dayCountLabel.textContent = "End date must be on or after the start date.";
      balRemaining.textContent = `${AVAILABLE_BALANCE} days`;
      return;
    }
    dayCountLabel.textContent = `This request covers ${days} day${days > 1 ? "s" : ""}.`;
    const remaining = AVAILABLE_BALANCE - days;
    balRemaining.textContent = `${remaining} day${remaining !== 1 ? "s" : ""}`;
    balRemaining.style.color = remaining < 0 ? "var(--danger)" : "";
  }

  startDate.addEventListener("change", updateSummary);
  endDate.addEventListener("change", updateSummary);

  // Upload
  uploadBox.addEventListener("click", () => fileInput.click());
  uploadBox.addEventListener("dragover", (e) => {
    e.preventDefault();
    uploadBox.classList.add("dragover");
  });
  uploadBox.addEventListener("dragleave", () => uploadBox.classList.remove("dragover"));
  uploadBox.addEventListener("drop", (e) => {
    e.preventDefault();
    uploadBox.classList.remove("dragover");
    if (e.dataTransfer.files.length) {
      fileInput.files = e.dataTransfer.files;
      showFile(e.dataTransfer.files[0]);
    }
  });
  fileInput.addEventListener("change", () => {
    if (fileInput.files.length) showFile(fileInput.files[0]);
  });

  function showFile(file) {
    fileNameWrap.innerHTML = `
      <div class="upload-filename">
        <span class="material-symbols-outlined">description</span>
        <span class="flex-grow-1">${file.name}</span>
        <button type="button" class="icon-btn p-1" id="removeFileBtn"><span class="material-symbols-outlined" style="font-size:16px">close</span></button>
      </div>`;
    document.getElementById("removeFileBtn").addEventListener("click", () => {
      fileInput.value = "";
      fileNameWrap.innerHTML = "";
    });
  }

  document.getElementById("cancelBtn").addEventListener("click", () => {
    form.reset();
    fileNameWrap.innerHTML = "";
    updateSummary();
  });

  form.addEventListener("submit", (e) => {
    e.preventDefault();
    if (!form.checkValidity()) {
      form.reportValidity();
      return;
    }
    const days = dayCount();
    if (days <= 0) {
      alert("Please select a valid date range before submitting.");
      return;
    }
    if (days > AVAILABLE_BALANCE) {
      alert("This request exceeds your available leave balance. You can still submit it for manager review.");
    }
    alert(`Leave request submitted for ${days} day${days > 1 ? "s" : ""}. You'll be notified once it's reviewed.`);
    window.location.href = "leave-requests.html";
  });

  updateSummary();
});
