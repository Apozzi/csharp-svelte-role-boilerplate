<script lang="ts">
  import { onMount } from 'svelte';
  import { fetchData, postData, putData } from '../../../lib/api';
    import { checkAdminAccess } from '$lib/userRoleManager';

  let user = { id: 0, name: '', email: '', password: '', roles: [] };
  let isEdit = false;
  let roles: any = [];

  onMount(async () => {
    checkAdminAccess();
    roles = await fetchData('/Role'); // Carregar todos os papéis
    const params = new URLSearchParams(window.location.search);
    const id = params.get('id');
    if (id) {
      isEdit = true;
      user = await fetchData(`/User/${id}`);
    }
  });

  async function handleSubmit() {
    if (isEdit) {
      await putData(`/User/${user.id}`, user);
    } else {
      await postData('/User', user);
    }
    window.location.href = '/usuario';
  }
</script>

<div class="flex justify-center items-center w-full">
  <div class="w-full max-w-3xl p-6">
    <h2 class="text-3xl font-semibold text-gray-800 mb-6 text-center">{isEdit ? 'Editar Usuário' : 'Adicionar Usuário'}</h2>

    <form on:submit|preventDefault={handleSubmit} class="w-full max-w-2xl mx-auto p-6 bg-white rounded-lg shadow-md space-y-6">
      <div>
        <label for="name" class="block text-sm font-medium text-gray-700">Nome</label>
        <input type="text" id="name" bind:value={user.name} required class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none" />
      </div>

      <div>
        <label for="email" class="block text-sm font-medium text-gray-700">Email</label>
        <input type="email" id="email" bind:value={user.email} required class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none" />
      </div>

      <div>
        <label for="password" class="block text-sm font-medium text-gray-700">Senha</label>
        <input type="password" id="password" bind:value={user.password} required class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none" />
      </div>

      <div>
        <label for="roles" class="block text-sm font-medium text-gray-700">Papéis</label>
        <select multiple id="roles" bind:value={user.roles} class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none">
          {#each roles as role}
            <option value={role.id}>{role.name}</option>
          {/each}
        </select>
      </div>

      <button type="submit" class="w-full py-2 px-4 bg-blue-600 text-white rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500">
        {isEdit ? 'Salvar' : 'Adicionar'}
      </button>
    </form>
  </div>
</div>