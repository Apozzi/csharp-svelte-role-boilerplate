<script lang="ts">
  import { onMount } from 'svelte';
  import { fetchData, deleteData } from '$lib/api';
    import { isModifier } from '$lib/userRoleManager';

  let items: any = [];
  let error = '';

  const fetchItems = async () => {
    try {
      items = await fetchData('/Item');
    } catch (err: any) {
      error = err.message || 'Erro desconhecido';
    }
  };

  const deleteItem = async (id: string) => {
    try {
      await deleteData(`/Item/${id}`);
      fetchItems();
    } catch (err: any) {
      error = err.message || 'Erro desconhecido';
    }
  };

  onMount(() => {
    fetchItems();
  });
</script>

<div class="flex-1 overflow-auto p-6">
  <h1 class="text-2xl font-semibold mb-6">Itens</h1>

  {#if error}
    <div class="bg-red-500 text-white p-4 mb-4 rounded">{error}</div>
  {/if}

  {#if isModifier()}
  <div class="mb-4">
    <a href={`/item/form`} class="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
      Adicionar
    </a>
  </div>
  {/if}

  <ul class="space-y-2">
    {#each items as item}
      <li class="flex justify-between items-center p-4 bg-gray-100 rounded-lg shadow">
        <span>{item.name}</span>
        <div>
          {#if isModifier()}
          <a href={`/item/form?id=${item.id}`} class="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
            Editar
          </a>
          <button
            on:click={() => deleteItem(item.id)}
            class="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700"
          >
            Deletar
          </button>
          {/if}
        </div>
      </li>
    {/each}
  </ul>
</div>