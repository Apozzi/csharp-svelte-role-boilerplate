<script lang="ts">
  import { onMount } from 'svelte';
  import { fetchData, deleteData } from '$lib/api';
    import { checkAdminAccess } from '$lib/userRoleManager';

  let roles: any = [];
  let error = '';

  const fetchRoles = async () => {
    try {
      roles = await fetchData('/Role');
    } catch (err: any) {
      error = err.message || 'Erro desconhecido';
    }
  };

  const deleteRole = async (id: string) => {
    try {
      await deleteData(`/Role/${id}`);
      fetchRoles();
    } catch (err: any) {
      error = err.message || 'Erro desconhecido';
    }
  };

  onMount(() => {
    checkAdminAccess();
    fetchRoles();
  });
</script>

<div class="flex-1 overflow-auto p-6">
  <h1 class="text-2xl font-semibold mb-6">Papéis</h1>

  {#if error}
    <div class="bg-red-500 text-white p-4 mb-4 rounded">{error}</div>
  {/if}

  <div class="mb-4">
    <a href={`/papel/form`} class="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
      Adicionar
    </a>
  </div>

  <ul class="space-y-2">
    {#each roles as role}
      <li class="flex justify-between items-center p-4 bg-gray-100 rounded-lg shadow">
        <span>{role.name}</span>
        <div>
          <a href={`/papel/form?id=${role.id}`} class="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
            Editar
          </a>
          <button
            on:click={() => deleteRole(role.id)}
            class="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700"
          >
            Deletar
          </button>
        </div>
      </li>
    {/each}
  </ul>
</div>