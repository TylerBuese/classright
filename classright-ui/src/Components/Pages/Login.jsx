import { useEffect, useState } from "react"
import loginRequest from "../../Helpers/loginUser";

export default function Login(props) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [loginError, setLoginError] = useState("");
    async function loginUser(e) {
        e.preventDefault();
        let data = await loginRequest(email, password)
        if (data.status == 200) {
            window.location = "/"
        } else {
            let e = await data.json()
            setLoginError(e.detail)
            
        } 
        


    }
    useEffect(() => {

        
    },[])
    return (
        <>
            <div class="flex items-center justify-center m-64">
                <div class="max-w-xs ">
                    <form class="bg-white shadow-md rounded  pl-12 pr-12 pt-12 pb-16 mb-4" onSubmit={loginUser}>
                        <div class="mb-4">
                            <label class="block text-gray-700 text-sm font-bold mb-2" for="email">
                                Email
                            </label>
                            <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="email" type="text" placeholder="jsmith@email.com" onInput={event => setEmail(event.target.value)}/>
                        </div>
                        <div class="mb-6">
                            <label class="block text-gray-700 text-sm font-bold mb-2" for="password">
                                Password
                            </label>
                            <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline" id="password" type="password" placeholder="******************" onInput={event => setPassword(event.target.value)}/>
                        </div>
                        <label class="block text-red-500 text-sm font-bold mb-2 -mt-7" for="email">{loginError}</label>
                        <div class="flex items-center justify-between">
                            <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="submit">
                                Sign In
                            </button>
                            <a class="inline-block align-baseline font-bold text-sm text-blue-500 hover:text-blue-800" href="#">
                                Forgot Password?
                            </a>
                        </div>
                    </form>
                    <p class="text-center text-gray-500 text-xs">
                        &copy;2023 ClassRight. All rights reserved.
                    </p>
                </div>
            </div>
            
        </>
    )
}