<script lang="ts">
  import { onMount } from "svelte";
  import { Chart, registerables } from "chart.js";

  Chart.register(...registerables);

  let barChartCanvas: any;
  let pieChartCanvas: any;

  onMount(() => {
    new Chart(barChartCanvas, {
      type: "bar",
      data: {
        labels: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio"],
        datasets: [
          {
            label: "Vendas (R$)",
            data: [5000, 7000, 4000, 8000, 9000],
            backgroundColor: [
              "#4CAF50",
              "#FF9800",
              "#2196F3",
              "#9C27B0",
              "#F44336",
            ],
            borderRadius: 10,
          },
        ],
      },
      options: {
        responsive: true,
        plugins: {
          legend: { display: true },
          tooltip: { enabled: true },
        },
        scales: {
          x: { grid: { display: false } },
          y: { beginAtZero: true },
        },
      },
    });

    new Chart(pieChartCanvas, {
      type: "pie",
      data: {
        labels: ["Produto A", "Produto B", "Produto C"],
        datasets: [
          {
            label: "Vendas por Produto",
            data: [40, 35, 25],
            backgroundColor: ["#4CAF50", "#2196F3", "#FFC107"],
            hoverOffset: 10,
          },
        ],
      },
      options: {
        responsive: true,
        plugins: {
          legend: { position: "bottom" },
          tooltip: { enabled: true },
        },
      },
    });
  });
</script>

<main class="bg-gray-100 min-h-screen w-full">
  <header class="p-8 bg-gradient-to-r from-blue-500 to-blue-700 text-white shadow-lg">
    <h1 class="text-4xl font-bold">Dashboard</h1>
    <p class="text-lg mt-2">Resumo do sistema</p>
  </header>

  <section class="p-8">
    <div class="grid grid-cols-1 md:grid-cols-3 gap-8 mb-8">
      <div class="bg-white p-6 shadow-lg rounded-lg text-center">
        <h2 class="text-xl font-semibold text-gray-600">Usuários Ativos</h2>
        <p class="text-4xl font-bold text-blue-500 mt-4">1</p>
      </div>
      <div class="bg-white p-6 shadow-lg rounded-lg text-center">
        <h2 class="text-xl font-semibold text-gray-600">Vendas Hoje</h2>
        <p class="text-4xl font-bold text-green-500 mt-4">R$ 2.500,00</p>
      </div>
      <div class="bg-white p-6 shadow-lg rounded-lg text-center">
        <h2 class="text-xl font-semibold text-gray-600">Novos Cadastros</h2>
        <p class="text-4xl font-bold text-red-500 mt-4">15</p>
      </div>
    </div>

    <div class="grid grid-cols-1 md:grid-cols-2 gap-8">
      <div class="bg-white p-6 shadow-lg rounded-lg">
        <canvas bind:this={barChartCanvas} class="max-w-full h-72"></canvas>
      </div>

      <div class="bg-white p-6 shadow-lg rounded-lg">
        <canvas bind:this={pieChartCanvas} class="max-w-full h-72"></canvas>
      </div>
    </div>
  </section>
</main>

<style>
  main {
    font-family: "Inter", Arial, sans-serif;
  }

  header {
    background-size: cover;
    background-position: center;
  }

  canvas {
    display: block;
    margin: 0 auto;
  }
</style>