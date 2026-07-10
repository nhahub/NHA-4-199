document.addEventListener("DOMContentLoaded", function () {
  const steps = document.querySelectorAll(".wizard-step");
  const panels = document.querySelectorAll(".step-panel");
  const successPanel = document.getElementById("successPanel");

  function goToStep(n) {
    steps.forEach((s) => {
      const num = Number(s.dataset.step);
      s.classList.remove("active", "done");
      const statusEl = s.querySelector(".wizard-step-status");
      if (num < n) {
        s.classList.add("done");
        statusEl.textContent = "Completed";
      } else if (num === n) {
        s.classList.add("active");
        statusEl.textContent = "In progress";
      } else {
        statusEl.textContent = "Not started";
      }
    });
    panels.forEach((p) => p.classList.add("d-none"));
    const target = document.getElementById(`panel${n}`);
    if (target) target.classList.remove("d-none");
  }

  document.querySelectorAll("[data-next]").forEach((btn) => {
    btn.addEventListener("click", () => goToStep(Number(btn.dataset.next)));
  });
  document.querySelectorAll("[data-back]").forEach((btn) => {
    btn.addEventListener("click", () => goToStep(Number(btn.dataset.back)));
  });

  // Step 2 — simulated calculation progress
  const startCalcBtn = document.getElementById("startCalcBtn");
  const calcIdle = document.getElementById("calcIdle");
  const calcRunning = document.getElementById("calcRunning");
  const calcDone = document.getElementById("calcDone");
  const progressBar = document.getElementById("calcProgressBar");
  const progressLabel = document.getElementById("calcProgressLabel");

  startCalcBtn.addEventListener("click", () => {
    calcIdle.classList.add("d-none");
    calcRunning.classList.remove("d-none");
    let pct = 0;
    const timer = setInterval(() => {
      pct += 20;
      if (pct >= 100) pct = 100;
      progressBar.style.width = `${pct}%`;
      progressLabel.textContent = `Calculating salaries... ${pct}%`;
      if (pct === 100) {
        clearInterval(timer);
        setTimeout(() => {
          calcRunning.classList.add("d-none");
          calcDone.classList.remove("d-none");
        }, 300);
      }
    }, 350);
  });

  // Step 4 — confirmation gate
  const confirmAck = document.getElementById("confirmAck");
  const confirmProcessBtn = document.getElementById("confirmProcessBtn");
  confirmAck.addEventListener("change", () => {
    confirmProcessBtn.disabled = !confirmAck.checked;
  });

  confirmProcessBtn.addEventListener("click", () => {
    confirmProcessBtn.disabled = true;
    confirmProcessBtn.textContent = "Processing...";
    setTimeout(() => {
      document.getElementById("wizardTrack").classList.add("d-none");
      document.getElementById("panel4").classList.add("d-none");
      successPanel.classList.remove("d-none");
    }, 900);
  });

  goToStep(1);
});
