import urls from "./actionableUrls";

export default async function loginRequest(email, password) {
    let options = {
        method: "post",
        body: JSON.stringify({
            email: email,
            password: password,
        }),
        headers: {
            "Content-Type": "application/json"
        },
        credentials: 'include'
    }

    return await fetch(urls.auth, options)

    
}