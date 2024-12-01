import prefixSelector from 'postcss-prefix-selector';

export default {
    plugins: {
        tailwindcss: {},
        autoprefixer: {},
        "postcss-prefix-selector": {
            prefix: '.react-container',
            transform: (prefix, selector, prefixedSelector) => {
                // Avoid prefixing `html` and `body` for global styles
                if (selector.startsWith('html') || selector.startsWith('body')) {
                    return prefix;
                }
                return prefixedSelector;
            }
        }
    }
};
