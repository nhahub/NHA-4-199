document.addEventListener("DOMContentLoaded", function () {
  const notesEl = document.getElementById("decisionNotes");
  const statusEl = document.getElementById("decisionStatus");
  const dateEl = document.getElementById("decisionDate");

  function today() {
    return new Date().toLocaleDateString("en-US", { month: "short", day: "numeric", year: "numeric" });
  }

  function recordDecision(label, chipClass) {
    if ((label === "Rejected" || label === "Changes Requested") && !notesEl.value.trim()) {
      alert("Please add approval notes explaining this decision.");
      notesEl.focus();
      return;
    }
    statusEl.innerHTML = `<span class="chip ${chipClass}">${label}</span>`;
    dateEl.textContent = today();
    dateEl.classList.remove("text-muted");
    alert(`Decision recorded: ${label}`);
  }

  document.getElementById("approveBtn").addEventListener("click", () => recordDecision("Approved", "chip-success"));
  document.getElementById("rejectBtn").addEventListener("click", () => recordDecision("Rejected", "chip-danger"));
  document.getElementById("requestChangesBtn").addEventListener("click", () => recordDecision("Changes Requested", "chip-primary"));
});
