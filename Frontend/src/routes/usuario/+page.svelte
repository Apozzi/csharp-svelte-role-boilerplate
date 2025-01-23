<script lang="ts">
  import { onMount } from 'svelte';
  import { fetchData, deleteData } from '$lib/api';
    import { checkAdminAccess } from '$lib/userRoleManager';

  let users: any = [];
  let error = '';

  const fetchUsers = async () => {
    try {
      users = await fetchData('/User');
    } catch (err: any) {
      error = err.message || 'Erro desconhecido';
    }
  };

  const deleteUser = async (id: string) => {
    try {
      await deleteData(`/User/${id}`);
      fetchUsers();
    } catch (err: any) {
      error = err.message || 'Erro desconhecido';
    }
  };

  onMount(() => {
    checkAdminAccess();
    fetchUsers();
  });
</script>

<div class="flex-1 overflow-auto p-6">
  <h1 class="text-2xl font-semibold mb-6">Usuários</h1>

  {#if error}
    <div class="bg-red-500 text-white p-4 mb-4 rounded">{error}</div>
  {/if}

  <div class="mb-4">
    <a href={`/usuario/form`} class="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
      Adicionar
    </a>
  </div>

  <ul class="space-y-2">
    {#each users as user}
      <li class="flex justify-between items-center p-4 bg-gray-100 rounded-lg shadow">
        <span>{user.name}</span>
        <div>
          <a href={`/usuario/form?id=${user.id}`} class="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
            Editar
          </a>
          <button
            on:click={() => deleteUser(user.id)}
            class="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700"
          >
            Deletar
          </button>
        </div>
      </li>
    {/each}
  </ul>
</div>