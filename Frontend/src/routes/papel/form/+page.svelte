<script lang="ts">
  import { onMount } from 'svelte';
  import { fetchData, postData, putData } from '../../../lib/api';
    import { checkAdminAccess } from '$lib/userRoleManager';

  let role: any = { id: 0, name: '' };
  let isEdit = false;

  onMount(async () => {
    checkAdminAccess();
    const params = new URLSearchParams(window.location.search);
    const id = params.get('id');
    if (id) {
      isEdit = true;
      role = await fetchData(`/Role/${id}`);
    }
  });

  async function handleSubmit() {
    if (isEdit) {
      await putData(`/Role/${role.id}`, role);
    } else {
      await postData('/Role', role);
    }
    window.location.href = '/papel';
  }
</script>

<div class="flex justify-center items-center w-full">
  <div class="w-full max-w-3xl p-6">
    <h2 class="text-3xl font-semibold text-gray-800 mb-6 text-center">{isEdit ? 'Editar Papel' : 'Adicionar Papel'}</h2>

    <form on:submit|preventDefault={handleSubmit} class="w-full max-w-2xl mx-auto p-6 bg-white rounded-lg shadow-md space-y-4">
      <div>
        <label for="name" class="block text-sm font-medium text-gray-700">Nome do Papel</label>
        <input type="text" id="name" bind:value={role.name} required class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none" />
      </div>

      <button type="submit" class="w-full py-2 px-4 bg-blue-600 text-white rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500">
        {isEdit ? 'Salvar' : 'Adicionar'}
      </button>
    </form>
  </div>
</div>