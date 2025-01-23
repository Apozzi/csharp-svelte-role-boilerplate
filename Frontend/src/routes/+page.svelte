<script lang="ts">
   import { browser } from '$app/environment';

   if (browser) {
    const token = window.localStorage.getItem('authToken');
    
    if (!token) {
        window.location.href = '/login';
    } else {
        window.location.href = '/dashboard';
    }
   }
  </script>
  
  <h1>Redirecionando...</h1>