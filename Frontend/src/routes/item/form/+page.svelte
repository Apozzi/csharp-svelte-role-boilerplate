<script lang="ts">
  import { onMount } from 'svelte';
  import { fetchData, postData, putData } from '../../../lib/api';
    import { checkModifierAccess } from '$lib/userRoleManager';

  let item : any = { id: 0, name: '', description: '', value: 0, owner: null };
  let isEdit = false;
  let users: any = [];
  let selectedOwnerId: any = null;

  onMount(async () => {
    checkModifierAccess();
    users = await fetchData('/User');
    const params = new URLSearchParams(window.location.search);
    const id = params.get('id');
    if (id) {
      isEdit = true;
      item = await fetchData(`/Item/${id}`);
      selectedOwnerId = item.owner?.id || null;
    }
  });

  async function handleSubmit() {
    if (selectedOwnerId) {
      item.owner = { id: selectedOwnerId };
    }

    if (isEdit) {
      await putData(`/Item/${item.id}`, item); 
    } else {
      await postData('/Item', item);
    }
    window.location.href = '/item'; 
  }
</script>

<div class="flex justify-center items-center w-full">
  <div class="w-full max-w-3xl p-6">
    <h2 class="text-2xl font-semibold mb-6">{isEdit ? 'Editar Item' : 'Adicionar Item'}</h2>

    <form on:submit|preventDefault={handleSubmit} class="w-full max-w-2xl mx-auto p-6 bg-white rounded-lg shadow-md space-y-4">
      <div>
        <label for="name" class="block text-sm font-medium text-gray-700">Nome do Item</label>
        <input type="text" id="name" bind:value={item.name} required class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none" />
      </div>

      <div>
        <label for="description" class="block text-sm font-medium text-gray-700">Descrição</label>
        <textarea id="description" bind:value={item.description} required class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none"></textarea>
      </div>

      <div>
        <label for="value" class="block text-sm font-medium text-gray-700">Valor</label>
        <input type="number" id="value" bind:value={item.value} required class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none" />
      </div>

      <div>
        <label for="owner" class="block text-sm font-medium text-gray-700">Proprietário</label>
        <select id="owner" bind:value={selectedOwnerId} class="mt-1 p-2 w-full border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:outline-none">
          <option value="" disabled selected>Selecione um usuário</option>
          {#each users as user}
            <option value={user.id}>{user.name}</option>
          {/each}
        </select>
      </div>

      <button type="submit" class="w-full py-2 px-4 bg-blue-600 text-white rounded-md hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500">
        {isEdit ? 'Salvar' : 'Adicionar'}
      </button>
    </form>
  </div>
</div>