<script>
    import { isAdmin } from "$lib/userRoleManager";

    let isOpen = true;
  </script>
  
  <div class="flex">
    <div class={`bg-gray-800 text-white w-64 h-screen p-5 ${isOpen ? 'block' : 'hidden'}`}>
      <div class="text-xl font-bold mb-6">Menu</div>
      <ul>
        <li class="mb-4">
          <a href="/item" class="flex items-center text-lg hover:bg-gray-700 p-2 rounded">
            <span>Item</span>
          </a>
        </li>
        {#if isAdmin()}
        <li class="mb-4">
          <a href="/papel" class="flex items-center text-lg hover:bg-gray-700 p-2 rounded">
            <span>Papel</span>
          </a>
        </li>
        <li class="mb-4">
          <a href="/usuario" class="flex items-center text-lg hover:bg-gray-700 p-2 rounded">
            <span>Usuário</span>
          </a>
        </li>
        {/if}
      </ul>
    </div>
  
  </div>
  
  <style>
    .sidebar {
      position: fixed;
      top: 0;
      left: 0;
      bottom: 0;
      width: 250px;
      background-color: #2d3748;
      color: white;
      padding: 20px;
      display: flex;
      flex-direction: column;
    }
    .sidebar a {
      color: white;
      text-decoration: none;
      margin-bottom: 15px;
      padding: 10px;
      border-radius: 5px;
    }
    .sidebar a:hover {
      background-color: #4a5568;
    }
  </style>