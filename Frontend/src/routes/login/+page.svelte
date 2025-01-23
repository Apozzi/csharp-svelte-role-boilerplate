<script lang="ts">
    let email = '';
    let password = '';
    let errorMessage = '';

    async function handleLogin(event: SubmitEvent) {
        event.preventDefault();

        if (!email || !password) {
            errorMessage = 'Por favor, preencha todos os campos.';
            return;
        }

        try {
            const response = await fetch('http://localhost:5125/api/Auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email, password }),
            });

            if (!response.ok) {
                const errorData = await response.json();
                errorMessage = errorData.message || 'Erro ao autenticar. Verifique suas credenciais.';
                return;
            }

            const data = await response.json();
            localStorage.setItem('token', data.token);
            window.location.href = '/dashboard';
        } catch (error) {
            errorMessage = 'Erro ao conectar com o servidor.';
            console.error(error);
        }
    }
</script>

<div class="bg-white shadow flex justify-center min-h-screen w-full" style="height: 100%;">
    <div class="lg:w-1/2 xl:w-5/12 p-6 sm:p-12">
        <div class="mt-12 flex flex-col items-center">
            <h1 class="text-5xl xl:text-4xl font-medium">
                Login
            </h1>
            <div class="w-full flex-1 mt-8">
                <form class="mx-auto max-w-xs" on:submit={handleLogin}>
                    <div class="relative mt-6">
                        <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                            Email Address
                        </label>
                        <input
                            type="email"
                            name="email"
                            id="email"
                            placeholder="Email Address"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            bind:value={email}
                        />
                    </div>
                    <div class="relative mt-6">
                        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                            Password
                        </label>
                        <input
                            type="password"
                            name="password"
                            id="password"
                            placeholder="Password"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            bind:value={password}
                        />
                    </div>
                    {#if errorMessage}
                        <p class="text-red-500 text-sm mt-2">{errorMessage}</p>
                    {/if}
                    <div class="flex items-center justify-between mt-8">
                        <button
                            type="submit"
                            class="btn flex items-center justify-center px-8 py-3 border border-transparent text-base font-normal rounded-md text-white bg-red-600 hover:bg-red-700 md:py-4 md:text-lg md:px-10">
                            Log In
                        </button>
                    </div>
                </form>
            </div>
            <div class="flex justify-evenly items-center space-x-2 w-80 mt-4">
                <span class="bg-gray-300 h-px flex-grow t-2 relative top-2"></span>
            </div>
        </div>
    </div>

    <div class="flex-1 bg-indigo-100 text-center hidden lg:flex">
        <div
            class="w-full bg-contain bg-center bg-no-repeat"
            style="background-image: url('https://adeveloper.com.br/img/banner.448ccda7.jpg');background-attachment: fixed;background-size: contain;background-position-x: right;">
        </div>
    </div>
</div>