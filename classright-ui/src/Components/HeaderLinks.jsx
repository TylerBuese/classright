export default function HeaderLinks(props) {
    return (
        <>
            <a href={props.obj[Object.keys(props.obj)[0]]} class="block mt-4 lg:inline-block lg:mt-0 text-slate-900 hover:text-slate-600 p-3">
                {Object.keys(props.obj)[0]} 
            </a>
        </>
    )
}