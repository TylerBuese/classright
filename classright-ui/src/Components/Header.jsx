import HeaderLinks from "./HeaderLinks"

export default function Header(props) {
    return(
        <>
            <header>
                <nav class="flex items-center justify-between flex-wrap p-6 bg-slate-50 border-b">
                    <div class="flex items-center flex-shrink-0 text-black mr-6">
                        <span class="font-semibold text-xl tracking-tight"></span>
                    </div>
                    <div class="w-full block flex-grow lg:flex lg:items-center lg:w-auto">
                        <div class="text-sm lg:flex-grow text-black ">
                            {props.routes.headerRoutes.map(e => <HeaderLinks obj={e}/>)}
                        </div>
                        
                    </div>
                </nav>
            </header>
        </>
    )
}