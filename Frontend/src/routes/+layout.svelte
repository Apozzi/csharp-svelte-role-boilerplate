<script lang="ts">
	import '../app.css';
	import { page } from '$app/stores';
	import Sidebar from '../lib/components/Sidebar.svelte';
	let showSide = $page.url.pathname !== '/login' && $page.url.pathname !== '/';
	let { children } = $props();
  </script>
  
<div class="flex" style="flex:auto;">
{#if showSide}
	<Sidebar />
{/if}

{@render children()}
</div>
 