/*! jQuery Migrate v1.4.1 | (c) jQuery Foundation and other contributors | jquery.org/license */
var vodi_options = {
    ajax_url: "https://demo2.madrasthemes.com/vodi-demos/main/wp-admin/admin-ajax.php",
deal_countdown_text: { days_text: "Days", hours_text: "Hours", mins_text: "Mins", secs_text: "Secs" },
enable_hh_sticky_header: "",
enable_sticky_header: "",
enable_vodi_readmore: "1",
rtl: "0",
vodi_episode_readmore_data: { moreLink: '<a class="maxlist-more" href="#">Read More</a>', lessLink: '<a class="maxlist-less" href="#">Show Less</a>', collapsedHeight: 47, speed: 600 },
vodi_video_readmore_data: { moreLink: '<a class="maxlist-more" href="#">Show more</a>', lessLink: '<a class="maxlist-less" href="#">Show less</a>', collapsedHeight: 0, speed: 600 },
wp_local_time_offset: "5.5"

};
"undefined" == typeof jQuery.migrateMute && (jQuery.migrateMute = !0),
    function (a, b, c) {
        function d(c) {
            var d = b.console;
            f[c] || (f[c] = !0, a.migrateWarnings.push(c), d && d.warn && !a.migrateMute && (d.warn("JQMIGRATE: " + c), a.migrateTrace && d.trace && d.trace()))
        }

        function e(b, c, e, f) {
            if (Object.defineProperty) try {
                return void Object.defineProperty(b, c, {
                    configurable: !0,
                    enumerable: !0,
                    get: function () {
                        return d(f), e
                    },
                    set: function (a) {
                        d(f), e = a
                    }
                })
            } catch (g) { }
            a._definePropertyBroken = !0, b[c] = e
        }
        a.migrateVersion = "1.4.1";
        var f = {};
        a.migrateWarnings = [], b.console && b.console.log && b.console.log("JQMIGRATE: Migrate is installed" + (a.migrateMute ? "" : " with logging active") + ", version " + a.migrateVersion), a.migrateTrace === c && (a.migrateTrace = !0), a.migrateReset = function () {
            f = {}, a.migrateWarnings.length = 0
        }, "BackCompat" === document.compatMode && d("jQuery is not compatible with Quirks Mode");
        var g = a("<input/>", {
            size: 1
        }).attr("size") && a.attrFn,
            h = a.attr,
            i = a.attrHooks.value && a.attrHooks.value.get || function () {
                return null
            },
            j = a.attrHooks.value && a.attrHooks.value.set || function () {
                return c
            },
            k = /^(?:input|button)$/i,
            l = /^[238]$/,
            m = /^(?:autofocus|autoplay|async|checked|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|selected)$/i,
            n = /^(?:checked|selected)$/i;
        e(a, "attrFn", g || {}, "jQuery.attrFn is deprecated"), a.attr = function (b, e, f, i) {
            var j = e.toLowerCase(),
                o = b && b.nodeType;
            return i && (h.length < 4 && d("jQuery.fn.attr( props, pass ) is deprecated"), b && !l.test(o) && (g ? e in g : a.isFunction(a.fn[e]))) ? a(b)[e](f) : ("type" === e && f !== c && k.test(b.nodeName) && b.parentNode && d("Can't change the 'type' of an input or button in IE 6/7/8"), !a.attrHooks[j] && m.test(j) && (a.attrHooks[j] = {
                get: function (b, d) {
                    var e, f = a.prop(b, d);
                    return f === !0 || "boolean" != typeof f && (e = b.getAttributeNode(d)) && e.nodeValue !== !1 ? d.toLowerCase() : c
                },
                set: function (b, c, d) {
                    var e;
                    return c === !1 ? a.removeAttr(b, d) : (e = a.propFix[d] || d, e in b && (b[e] = !0), b.setAttribute(d, d.toLowerCase())), d
                }
            }, n.test(j) && d("jQuery.fn.attr('" + j + "') might use property instead of attribute")), h.call(a, b, e, f))
        }, a.attrHooks.value = {
            get: function (a, b) {
                var c = (a.nodeName || "").toLowerCase();
                return "button" === c ? i.apply(this, arguments) : ("input" !== c && "option" !== c && d("jQuery.fn.attr('value') no longer gets properties"), b in a ? a.value : null)
            },
            set: function (a, b) {
                var c = (a.nodeName || "").toLowerCase();
                return "button" === c ? j.apply(this, arguments) : ("input" !== c && "option" !== c && d("jQuery.fn.attr('value', val) no longer sets properties"), void (a.value = b))
            }
        };
        var o, p, q = a.fn.init,
            r = a.find,
            s = a.parseJSON,
            t = /^\s*</,
            u = /\[(\s*[-\w]+\s*)([~|^$*]?=)\s*([-\w#]*?#[-\w#]*)\s*\]/,
            v = /\[(\s*[-\w]+\s*)([~|^$*]?=)\s*([-\w#]*?#[-\w#]*)\s*\]/g,
            w = /^([^<]*)(<[\w\W]+>)([^>]*)$/;
        a.fn.init = function (b, e, f) {
            var g, h;
            return b && "string" == typeof b && !a.isPlainObject(e) && (g = w.exec(a.trim(b))) && g[0] && (t.test(b) || d("$(html) HTML strings must start with '<' character"), g[3] && d("$(html) HTML text after last tag is ignored"), "#" === g[0].charAt(0) && (d("HTML string cannot start with a '#' character"), a.error("JQMIGRATE: Invalid selector string (XSS)")), e && e.context && e.context.nodeType && (e = e.context), a.parseHTML) ? q.call(this, a.parseHTML(g[2], e && e.ownerDocument || e || document, !0), e, f) : (h = q.apply(this, arguments), b && b.selector !== c ? (h.selector = b.selector, h.context = b.context) : (h.selector = "string" == typeof b ? b : "", b && (h.context = b.nodeType ? b : e || document)), h)
        }, a.fn.init.prototype = a.fn, a.find = function (a) {
            var b = Array.prototype.slice.call(arguments);
            if ("string" == typeof a && u.test(a)) try {
                document.querySelector(a)
            } catch (c) {
                a = a.replace(v, function (a, b, c, d) {
                    return "[" + b + c + '"' + d + '"]'
                });
                try {
                    document.querySelector(a), d("Attribute selector with '#' must be quoted: " + b[0]), b[0] = a
                } catch (e) {
                    d("Attribute selector with '#' was not fixed: " + b[0])
                }
            }
            return r.apply(this, b)
        };
        var x;
        for (x in r) Object.prototype.hasOwnProperty.call(r, x) && (a.find[x] = r[x]);
        a.parseJSON = function (a) {
            return a ? s.apply(this, arguments) : (d("jQuery.parseJSON requires a valid JSON string"), null)
        }, a.uaMatch = function (a) {
            a = a.toLowerCase();
            var b = /(chrome)[ \/]([\w.]+)/.exec(a) || /(webkit)[ \/]([\w.]+)/.exec(a) || /(opera)(?:.*version|)[ \/]([\w.]+)/.exec(a) || /(msie) ([\w.]+)/.exec(a) || a.indexOf("compatible") < 0 && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(a) || [];
            return {
                browser: b[1] || "",
                version: b[2] || "0"
            }
        }, a.browser || (o = a.uaMatch(navigator.userAgent), p = {}, o.browser && (p[o.browser] = !0, p.version = o.version), p.chrome ? p.webkit = !0 : p.webkit && (p.safari = !0), a.browser = p), e(a, "browser", a.browser, "jQuery.browser is deprecated"), a.boxModel = a.support.boxModel = "CSS1Compat" === document.compatMode, e(a, "boxModel", a.boxModel, "jQuery.boxModel is deprecated"), e(a.support, "boxModel", a.support.boxModel, "jQuery.support.boxModel is deprecated"), a.sub = function () {
            function b(a, c) {
                return new b.fn.init(a, c)
            }
            a.extend(!0, b, this), b.superclass = this, b.fn = b.prototype = this(), b.fn.constructor = b, b.sub = this.sub, b.fn.init = function (d, e) {
                var f = a.fn.init.call(this, d, e, c);
                return f instanceof b ? f : b(f)
            }, b.fn.init.prototype = b.fn;
            var c = b(document);
            return d("jQuery.sub() is deprecated"), b
        }, a.fn.size = function () {
            return d("jQuery.fn.size() is deprecated; use the .length property"), this.length
        };
        var y = !1;
        a.swap && a.each(["height", "width", "reliableMarginRight"], function (b, c) {
            var d = a.cssHooks[c] && a.cssHooks[c].get;
            d && (a.cssHooks[c].get = function () {
                var a;
                return y = !0, a = d.apply(this, arguments), y = !1, a
            })
        }), a.swap = function (a, b, c, e) {
            var f, g, h = {};
            y || d("jQuery.swap() is undocumented and deprecated");
            for (g in b) h[g] = a.style[g], a.style[g] = b[g];
            f = c.apply(a, e || []);
            for (g in b) a.style[g] = h[g];
            return f
        }, a.ajaxSetup({
            converters: {
                "text json": a.parseJSON
            }
        });
        var z = a.fn.data;
        a.fn.data = function (b) {
            var e, f, g = this[0];
            return !g || "events" !== b || 1 !== arguments.length || (e = a.data(g, b), f = a._data(g, b), e !== c && e !== f || f === c) ? z.apply(this, arguments) : (d("Use of jQuery.fn.data('events') is deprecated"), f)
        };
        var A = /\/(java|ecma)script/i;
        a.clean || (a.clean = function (b, c, e, f) {
            c = c || document, c = !c.nodeType && c[0] || c, c = c.ownerDocument || c, d("jQuery.clean() is deprecated");
            var g, h, i, j, k = [];
            if (a.merge(k, a.buildFragment(b, c).childNodes), e)
                for (i = function (a) {
                    return !a.type || A.test(a.type) ? f ? f.push(a.parentNode ? a.parentNode.removeChild(a) : a) : e.appendChild(a) : void 0
                }, g = 0; null != (h = k[g]); g++) a.nodeName(h, "script") && i(h) || (e.appendChild(h), "undefined" != typeof h.getElementsByTagName && (j = a.grep(a.merge([], h.getElementsByTagName("script")), i), k.splice.apply(k, [g + 1, 0].concat(j)), g += j.length));
            return k
        });
        var B = a.event.add,
            C = a.event.remove,
            D = a.event.trigger,
            E = a.fn.toggle,
            F = a.fn.live,
            G = a.fn.die,
            H = a.fn.load,
            I = "ajaxStart|ajaxStop|ajaxSend|ajaxComplete|ajaxError|ajaxSuccess",
            J = new RegExp("\\b(?:" + I + ")\\b"),
            K = /(?:^|\s)hover(\.\S+|)\b/,
            L = function (b) {
                return "string" != typeof b || a.event.special.hover ? b : (K.test(b) && d("'hover' pseudo-event is deprecated, use 'mouseenter mouseleave'"), b && b.replace(K, "mouseenter$1 mouseleave$1"))
            };
        a.event.props && "attrChange" !== a.event.props[0] && a.event.props.unshift("attrChange", "attrName", "relatedNode", "srcElement"), a.event.dispatch && e(a.event, "handle", a.event.dispatch, "jQuery.event.handle is undocumented and deprecated"), a.event.add = function (a, b, c, e, f) {
            a !== document && J.test(b) && d("AJAX events should be attached to document: " + b), B.call(this, a, L(b || ""), c, e, f)
        }, a.event.remove = function (a, b, c, d, e) {
            C.call(this, a, L(b) || "", c, d, e)
        }, a.each(["load", "unload", "error"], function (b, c) {
            a.fn[c] = function () {
                var a = Array.prototype.slice.call(arguments, 0);
                return "load" === c && "string" == typeof a[0] ? H.apply(this, a) : (d("jQuery.fn." + c + "() is deprecated"), a.splice(0, 0, c), arguments.length ? this.bind.apply(this, a) : (this.triggerHandler.apply(this, a), this))
            }
        }), a.fn.toggle = function (b, c) {
            if (!a.isFunction(b) || !a.isFunction(c)) return E.apply(this, arguments);
            d("jQuery.fn.toggle(handler, handler...) is deprecated");
            var e = arguments,
                f = b.guid || a.guid++,
                g = 0,
                h = function (c) {
                    var d = (a._data(this, "lastToggle" + b.guid) || 0) % g;
                    return a._data(this, "lastToggle" + b.guid, d + 1), c.preventDefault(), e[d].apply(this, arguments) || !1
                };
            for (h.guid = f; g < e.length;) e[g++].guid = f;
            return this.click(h)
        }, a.fn.live = function (b, c, e) {
            return d("jQuery.fn.live() is deprecated"), F ? F.apply(this, arguments) : (a(this.context).on(b, this.selector, c, e), this)
        }, a.fn.die = function (b, c) {
            return d("jQuery.fn.die() is deprecated"), G ? G.apply(this, arguments) : (a(this.context).off(b, this.selector || "**", c), this)
        }, a.event.trigger = function (a, b, c, e) {
            return c || J.test(a) || d("Global events are undocumented and deprecated"), D.call(this, a, b, c || document, e)
        }, a.each(I.split("|"), function (b, c) {
            a.event.special[c] = {
                setup: function () {
                    var b = this;
                    return b !== document && (a.event.add(document, c + "." + a.guid, function () {
                        a.event.trigger(c, Array.prototype.slice.call(arguments, 1), b, !0)
                    }), a._data(this, c, a.guid++)), !1
                },
                teardown: function () {
                    return this !== document && a.event.remove(document, c + "." + a._data(this, c)), !1
                }
            }
        }), a.event.special.ready = {
            setup: function () {
                this === document && d("'ready' event is deprecated")
            }
        };
        var M = a.fn.andSelf || a.fn.addBack,
            N = a.fn.find;
        if (a.fn.andSelf = function () {
            return d("jQuery.fn.andSelf() replaced by jQuery.fn.addBack()"), M.apply(this, arguments)
        }, a.fn.find = function (a) {
            var b = N.apply(this, arguments);
            return b.context = this.context, b.selector = this.selector ? this.selector + " " + a : a, b
        }, a.Callbacks) {
            var O = a.Deferred,
                P = [
                    ["resolve", "done", a.Callbacks("once memory"), a.Callbacks("once memory"), "resolved"],
                    ["reject", "fail", a.Callbacks("once memory"), a.Callbacks("once memory"), "rejected"],
                    ["notify", "progress", a.Callbacks("memory"), a.Callbacks("memory")]
                ];
            a.Deferred = function (b) {
                var c = O(),
                    e = c.promise();
                return c.pipe = e.pipe = function () {
                    var b = arguments;
                    return d("deferred.pipe() is deprecated"), a.Deferred(function (d) {
                        a.each(P, function (f, g) {
                            var h = a.isFunction(b[f]) && b[f];
                            c[g[1]](function () {
                                var b = h && h.apply(this, arguments);
                                b && a.isFunction(b.promise) ? b.promise().done(d.resolve).fail(d.reject).progress(d.notify) : d[g[0] + "With"](this === e ? d.promise() : this, h ? [b] : arguments)
                            })
                        }), b = null
                    }).promise()
                }, c.isResolved = function () {
                    return d("deferred.isResolved is deprecated"), "resolved" === c.state()
                }, c.isRejected = function () {
                    return d("deferred.isRejected is deprecated"), "rejected" === c.state()
                }, b && b.call(c, c), c
            }
        }
    }(jQuery, window);
var c = document.body.className;
c = c.replace(/masvideos-no-js/, 'masvideos-js');
document.body.className = c;
(function ($) {
    'use strict';
    if (typeof wpcf7 === 'undefined' || wpcf7 === null) {
        return
    }
    wpcf7 = $.extend({
        cached: 0,
        inputs: []
    }, wpcf7);
    $(function () {
        wpcf7.supportHtml5 = (function () {
            var features = {};
            var input = document.createElement('input');
            features.placeholder = 'placeholder' in input;
            var inputTypes = ['email', 'url', 'tel', 'number', 'range', 'date'];
            $.each(inputTypes, function (index, value) {
                input.setAttribute('type', value);
                features[value] = input.type !== 'text'
            });
            return features
        })();
        $('div.wpcf7 > form').each(function () {
            var $form = $(this);
            wpcf7.initForm($form);
            if (wpcf7.cached) {
                wpcf7.refill($form)
            }
        })
    });
    wpcf7.getId = function (form) {
        return parseInt($('input[name="_wpcf7"]', form).val(), 10)
    };
    wpcf7.initForm = function (form) {
        var $form = $(form);
        $form.submit(function (event) {
            if (!wpcf7.supportHtml5.placeholder) {
                $('[placeholder].placeheld', $form).each(function (i, n) {
                    $(n).val('').removeClass('placeheld')
                })
            }
            if (typeof window.FormData === 'function') {
                wpcf7.submit($form);
                event.preventDefault()
            }
        });
        $('.wpcf7-submit', $form).after('<span class="ajax-loader"></span>');
        wpcf7.toggleSubmit($form);
        $form.on('click', '.wpcf7-acceptance', function () {
            wpcf7.toggleSubmit($form)
        });
        $('.wpcf7-exclusive-checkbox', $form).on('click', 'input:checkbox', function () {
            var name = $(this).attr('name');
            $form.find('input:checkbox[name="' + name + '"]').not(this).prop('checked', !1)
        });
        $('.wpcf7-list-item.has-free-text', $form).each(function () {
            var $freetext = $(':input.wpcf7-free-text', this);
            var $wrap = $(this).closest('.wpcf7-form-control');
            if ($(':checkbox, :radio', this).is(':checked')) {
                $freetext.prop('disabled', !1)
            } else {
                $freetext.prop('disabled', !0)
            }
            $wrap.on('change', ':checkbox, :radio', function () {
                var $cb = $('.has-free-text', $wrap).find(':checkbox, :radio');
                if ($cb.is(':checked')) {
                    $freetext.prop('disabled', !1).focus()
                } else {
                    $freetext.prop('disabled', !0)
                }
            })
        });
        if (!wpcf7.supportHtml5.placeholder) {
            $('[placeholder]', $form).each(function () {
                $(this).val($(this).attr('placeholder'));
                $(this).addClass('placeheld');
                $(this).focus(function () {
                    if ($(this).hasClass('placeheld')) {
                        $(this).val('').removeClass('placeheld')
                    }
                });
                $(this).blur(function () {
                    if ('' === $(this).val()) {
                        $(this).val($(this).attr('placeholder'));
                        $(this).addClass('placeheld')
                    }
                })
            })
        }
        if (wpcf7.jqueryUi && !wpcf7.supportHtml5.date) {
            $form.find('input.wpcf7-date[type="date"]').each(function () {
                $(this).datepicker({
                    dateFormat: 'yy-mm-dd',
                    minDate: new Date($(this).attr('min')),
                    maxDate: new Date($(this).attr('max'))
                })
            })
        }
        if (wpcf7.jqueryUi && !wpcf7.supportHtml5.number) {
            $form.find('input.wpcf7-number[type="number"]').each(function () {
                $(this).spinner({
                    min: $(this).attr('min'),
                    max: $(this).attr('max'),
                    step: $(this).attr('step')
                })
            })
        }
        $('.wpcf7-character-count', $form).each(function () {
            var $count = $(this);
            var name = $count.attr('data-target-name');
            var down = $count.hasClass('down');
            var starting = parseInt($count.attr('data-starting-value'), 10);
            var maximum = parseInt($count.attr('data-maximum-value'), 10);
            var minimum = parseInt($count.attr('data-minimum-value'), 10);
            var updateCount = function (target) {
                var $target = $(target);
                var length = $target.val().length;
                var count = down ? starting - length : length;
                $count.attr('data-current-value', count);
                $count.text(count);
                if (maximum && maximum < length) {
                    $count.addClass('too-long')
                } else {
                    $count.removeClass('too-long')
                }
                if (minimum && length < minimum) {
                    $count.addClass('too-short')
                } else {
                    $count.removeClass('too-short')
                }
            };
            $(':input[name="' + name + '"]', $form).each(function () {
                updateCount(this);
                $(this).keyup(function () {
                    updateCount(this)
                })
            })
        });
        $form.on('change', '.wpcf7-validates-as-url', function () {
            var val = $.trim($(this).val());
            if (val && !val.match(/^[a-z][a-z0-9.+-]*:/i) && -1 !== val.indexOf('.')) {
                val = val.replace(/^\/+/, '');
                val = 'http://' + val
            }
            $(this).val(val)
        })
    };
    wpcf7.submit = function (form) {
        if (typeof window.FormData !== 'function') {
            return
        }
        var $form = $(form);
        $('.ajax-loader', $form).addClass('is-active');
        wpcf7.clearResponse($form);
        var formData = new FormData($form.get(0));
        var detail = {
            id: $form.closest('div.wpcf7').attr('id'),
            status: 'init',
            inputs: [],
            formData: formData
        };
        $.each($form.serializeArray(), function (i, field) {
            if ('_wpcf7' == field.name) {
                detail.contactFormId = field.value
            } else if ('_wpcf7_version' == field.name) {
                detail.pluginVersion = field.value
            } else if ('_wpcf7_locale' == field.name) {
                detail.contactFormLocale = field.value
            } else if ('_wpcf7_unit_tag' == field.name) {
                detail.unitTag = field.value
            } else if ('_wpcf7_container_post' == field.name) {
                detail.containerPostId = field.value
            } else if (field.name.match(/^_wpcf7_\w+_free_text_/)) {
                var owner = field.name.replace(/^_wpcf7_\w+_free_text_/, '');
                detail.inputs.push({
                    name: owner + '-free-text',
                    value: field.value
                })
            } else if (field.name.match(/^_/)) { } else {
                detail.inputs.push(field)
            }
        });
        wpcf7.triggerEvent($form.closest('div.wpcf7'), 'beforesubmit', detail);
        var ajaxSuccess = function (data, status, xhr, $form) {
            detail.id = $(data.into).attr('id');
            detail.status = data.status;
            detail.apiResponse = data;
            var $message = $('.wpcf7-response-output', $form);
            switch (data.status) {
                case 'validation_failed':
                    $.each(data.invalidFields, function (i, n) {
                        $(n.into, $form).each(function () {
                            wpcf7.notValidTip(this, n.message);
                            $('.wpcf7-form-control', this).addClass('wpcf7-not-valid');
                            $('[aria-invalid]', this).attr('aria-invalid', 'true')
                        })
                    });
                    $message.addClass('wpcf7-validation-errors');
                    $form.addClass('invalid');
                    wpcf7.triggerEvent(data.into, 'invalid', detail);
                    break;
                case 'acceptance_missing':
                    $message.addClass('wpcf7-acceptance-missing');
                    $form.addClass('unaccepted');
                    wpcf7.triggerEvent(data.into, 'unaccepted', detail);
                    break;
                case 'spam':
                    $message.addClass('wpcf7-spam-blocked');
                    $form.addClass('spam');
                    wpcf7.triggerEvent(data.into, 'spam', detail);
                    break;
                case 'aborted':
                    $message.addClass('wpcf7-aborted');
                    $form.addClass('aborted');
                    wpcf7.triggerEvent(data.into, 'aborted', detail);
                    break;
                case 'mail_sent':
                    $message.addClass('wpcf7-mail-sent-ok');
                    $form.addClass('sent');
                    wpcf7.triggerEvent(data.into, 'mailsent', detail);
                    break;
                case 'mail_failed':
                    $message.addClass('wpcf7-mail-sent-ng');
                    $form.addClass('failed');
                    wpcf7.triggerEvent(data.into, 'mailfailed', detail);
                    break;
                default:
                    var customStatusClass = 'custom-' + data.status.replace(/[^0-9a-z]+/i, '-');
                    $message.addClass('wpcf7-' + customStatusClass);
                    $form.addClass(customStatusClass)
            }
            wpcf7.refill($form, data);
            wpcf7.triggerEvent(data.into, 'submit', detail);
            if ('mail_sent' == data.status) {
                $form.each(function () {
                    this.reset()
                });
                wpcf7.toggleSubmit($form)
            }
            if (!wpcf7.supportHtml5.placeholder) {
                $form.find('[placeholder].placeheld').each(function (i, n) {
                    $(n).val($(n).attr('placeholder'))
                })
            }
            $message.html('').append(data.message).slideDown('fast');
            $message.attr('role', 'alert');
            $('.screen-reader-response', $form.closest('.wpcf7')).each(function () {
                var $response = $(this);
                $response.html('').attr('role', '').append(data.message);
                if (data.invalidFields) {
                    var $invalids = $('<ul></ul>');
                    $.each(data.invalidFields, function (i, n) {
                        if (n.idref) {
                            var $li = $('<li></li>').append($('<a></a>').attr('href', '#' + n.idref).append(n.message))
                        } else {
                            var $li = $('<li></li>').append(n.message)
                        }
                        $invalids.append($li)
                    });
                    $response.append($invalids)
                }
                $response.attr('role', 'alert').focus()
            })
        };
        $.ajax({
            type: 'POST',
            url: wpcf7.apiSettings.getRoute('/contact-forms/' + wpcf7.getId($form) + '/feedback'),
            data: formData,
            dataType: 'json',
            processData: !1,
            contentType: !1
        }).done(function (data, status, xhr) {
            ajaxSuccess(data, status, xhr, $form);
            $('.ajax-loader', $form).removeClass('is-active')
        }).fail(function (xhr, status, error) {
            var $e = $('<div class="ajax-error"></div>').text(error.message);
            $form.after($e)
        })
    };
    wpcf7.triggerEvent = function (target, name, detail) {
        var $target = $(target);
        var event = new CustomEvent('wpcf7' + name, {
            bubbles: !0,
            detail: detail
        });
        $target.get(0).dispatchEvent(event);
        $target.trigger('wpcf7:' + name, detail);
        $target.trigger(name + '.wpcf7', detail)
    };
    wpcf7.toggleSubmit = function (form, state) {
        var $form = $(form);
        var $submit = $('input:submit', $form);
        if (typeof state !== 'undefined') {
            $submit.prop('disabled', !state);
            return
        }
        if ($form.hasClass('wpcf7-acceptance-as-validation')) {
            return
        }
        $submit.prop('disabled', !1);
        $('.wpcf7-acceptance', $form).each(function () {
            var $span = $(this);
            var $input = $('input:checkbox', $span);
            if (!$span.hasClass('optional')) {
                if ($span.hasClass('invert') && $input.is(':checked') || !$span.hasClass('invert') && !$input.is(':checked')) {
                    $submit.prop('disabled', !0);
                    return !1
                }
            }
        })
    };
    wpcf7.notValidTip = function (target, message) {
        var $target = $(target);
        $('.wpcf7-not-valid-tip', $target).remove();
        $('<span role="alert" class="wpcf7-not-valid-tip"></span>').text(message).appendTo($target);
        if ($target.is('.use-floating-validation-tip *')) {
            var fadeOut = function (target) {
                $(target).not(':hidden').animate({
                    opacity: 0
                }, 'fast', function () {
                    $(this).css({
                        'z-index': -100
                    })
                })
            };
            $target.on('mouseover', '.wpcf7-not-valid-tip', function () {
                fadeOut(this)
            });
            $target.on('focus', ':input', function () {
                fadeOut($('.wpcf7-not-valid-tip', $target))
            })
        }
    };
    wpcf7.refill = function (form, data) {
        var $form = $(form);
        var refillCaptcha = function ($form, items) {
            $.each(items, function (i, n) {
                $form.find(':input[name="' + i + '"]').val('');
                $form.find('img.wpcf7-captcha-' + i).attr('src', n);
                var match = /([0-9]+)\.(png|gif|jpeg)$/.exec(n);
                $form.find('input:hidden[name="_wpcf7_captcha_challenge_' + i + '"]').attr('value', match[1])
            })
        };
        var refillQuiz = function ($form, items) {
            $.each(items, function (i, n) {
                $form.find(':input[name="' + i + '"]').val('');
                $form.find(':input[name="' + i + '"]').siblings('span.wpcf7-quiz-label').text(n[0]);
                $form.find('input:hidden[name="_wpcf7_quiz_answer_' + i + '"]').attr('value', n[1])
            })
        };
        if (typeof data === 'undefined') {
            $.ajax({
                type: 'GET',
                url: wpcf7.apiSettings.getRoute('/contact-forms/' + wpcf7.getId($form) + '/refill'),
                beforeSend: function (xhr) {
                    var nonce = $form.find(':input[name="_wpnonce"]').val();
                    if (nonce) {
                        xhr.setRequestHeader('X-WP-Nonce', nonce)
                    }
                },
                dataType: 'json'
            }).done(function (data, status, xhr) {
                if (data.captcha) {
                    refillCaptcha($form, data.captcha)
                }
                if (data.quiz) {
                    refillQuiz($form, data.quiz)
                }
            })
        } else {
            if (data.captcha) {
                refillCaptcha($form, data.captcha)
            }
            if (data.quiz) {
                refillQuiz($form, data.quiz)
            }
        }
    };
    wpcf7.clearResponse = function (form) {
        var $form = $(form);
        $form.removeClass('invalid spam sent failed');
        $form.siblings('.screen-reader-response').html('').attr('role', '');
        $('.wpcf7-not-valid-tip', $form).remove();
        $('[aria-invalid]', $form).attr('aria-invalid', 'false');
        $('.wpcf7-form-control', $form).removeClass('wpcf7-not-valid');
        $('.wpcf7-response-output', $form).hide().empty().removeAttr('role').removeClass('wpcf7-mail-sent-ok wpcf7-mail-sent-ng wpcf7-validation-errors wpcf7-spam-blocked')
    };
    wpcf7.apiSettings.getRoute = function (path) {
        var url = wpcf7.apiSettings.root;
        url = url.replace(wpcf7.apiSettings.namespace, wpcf7.apiSettings.namespace + path);
        return url
    }
})(jQuery);
(function () {
    if (typeof window.CustomEvent === "function") return !1;

    function CustomEvent(event, params) {
        params = params || {
            bubbles: !1,
            cancelable: !1,
            detail: undefined
        };
        var evt = document.createEvent('CustomEvent');
        evt.initCustomEvent(event, params.bubbles, params.cancelable, params.detail);
        return evt
    }
    CustomEvent.prototype = window.Event.prototype;
    window.CustomEvent = CustomEvent
})();
jQuery(function (o) {
    if ("undefined" == typeof masvideos_playlist_tv_show_params) return !1;
    o(document).on("click", ".masvideos-ajax-toggle-tv-show-playlist", function (t) {
        var a = o(this);
        if (!a.attr("data-playlist_id")) return !0;
        if (!a.attr("data-tv_show_id")) return !0;
        t.preventDefault();
        var e = {
            "delete": a.is(".added")
        };
        o.each(a.data(), function (t, a) {
            e[t] = a
        }), o(document.body).trigger("toggle_tv_show_playlist_before", [a, e]), o.post(masvideos_playlist_tv_show_params.masvideos_ajax_url.toString().replace("%%endpoint%%", "toggle_tv_show_playlist"), e, function (t) {
            t && (t.error && t.tv_show_url ? window.location = t.tv_show_url : (a.toggleClass("added"), o(document.body).trigger("toggle_tv_show_playlist_after", [t.html, a, e])))
        })
    })
});
jQuery(function (a) {
    if ("undefined" == typeof masvideos_playlist_video_params) return !1;
    a(document).on("click", ".masvideos-ajax-toggle-video-playlist", function (e) {
        var t = a(this);
        if (!t.attr("data-playlist_id")) return !0;
        if (!t.attr("data-video_id")) return !0;
        e.preventDefault();
        var i = {
            "delete": t.is(".added")
        };
        a.each(t.data(), function (e, t) {
            i[e] = t
        }), a(document.body).trigger("toggle_video_playlist_before", [t, i]), a.post(masvideos_playlist_video_params.masvideos_ajax_url.toString().replace("%%endpoint%%", "toggle_video_playlist"), i, function (e) {
            e && (e.error && e.video_url ? window.location = e.video_url : (t.toggleClass("added"), a(document.body).trigger("toggle_video_playlist_after", [e.html, t, i])))
        })
    })
});
jQuery(function (a) {
    if ("undefined" == typeof masvideos_playlist_movie_params) return !1;
    a(document).on("click", ".masvideos-ajax-toggle-movie-playlist", function (e) {
        var t = a(this);
        if (!t.attr("data-playlist_id")) return !0;
        if (!t.attr("data-movie_id")) return !0;
        e.preventDefault();
        var i = {
            "delete": t.is(".added")
        };
        a.each(t.data(), function (e, t) {
            i[e] = t
        }), a(document.body).trigger("toggle_movie_playlist_before", [t, i]), a.post(masvideos_playlist_movie_params.masvideos_ajax_url.toString().replace("%%endpoint%%", "toggle_movie_playlist"), i, function (e) {
            e && (e.error && e.movie_url ? window.location = e.movie_url : (t.toggleClass("added"), a(document.body).trigger("toggle_movie_playlist_after", [e.html, t, i])))
        })
    })
});
! function (o, t) {
    "use strict";
    o(document).ready(function () {
        o(".videos .video__poster").each(function () {
            var r = o(this).find(".video__poster--image"),
                t = r.attr("data-gallery-images"),
                i = JSON.parse(t),
                e = r.attr("src"),
                n = r.attr("srcset"),
                s = !1;
            o(this).on("mouseenter", function () {
                s = !0,
                    function n() {
                        0 < i.length && o.each(i, function (t, e) {
                            setTimeout(function () {
                                if (!s) return !1;
                                r.attr("src", e), r.attr("srcset", e), i.length == t + 1 && setTimeout(function () {
                                    n()
                                }, 800)
                            }, 800 * t)
                        })
                    }()
            }), o(this).on("mouseleave", function () {
                s = !1, r.attr("src", e), r.attr("srcset", n)
            })
        })
    })
}(jQuery, window);
! function (s, e, t, i) {
    "use strict";
    var n = "WordpressUlikeNotifications",
        a = {
            messageType: "success",
            messageText: "Hello World!",
            messageElement: "wpulike-message",
            notifContainer: "wpulike-notification"
        };

    function l(e, t) {
        this.element = e, this.$element = s(e), this.settings = s.extend({}, a, t), this._defaults = a, this._name = n, this.init()
    }
    s.extend(l.prototype, {
        init: function () {
            this._message(), this._container(), this._append(), this._remove()
        },
        _message: function () {
            this.$messageElement = s("<div/>").addClass(this.settings.messageElement + " wpulike-" + this.settings.messageType).text(this.settings.messageText)
        },
        _container: function () {
            s("." + this.settings.notifContainer).length || this.$element.append(s("<div/>").addClass(this.settings.notifContainer)), this.$notifContainer = this.$element.find("." + this.settings.notifContainer)
        },
        _append: function () {
            this.$notifContainer.append(this.$messageElement).trigger("WordpressUlikeNotificationAppend")
        },
        _remove: function () {
            var e = this;
            this.$messageElement.click(function () {
                s(this).fadeOut(300, function () {
                    s(this).remove(), s("." + e.settings.messageElement).length || e.$notifContainer.remove()
                }).trigger("WordpressUlikeRemoveNotification")
            }), setTimeout(function () {
                e.$messageElement.fadeOut(300, function () {
                    s(this).remove(), s("." + e.settings.messageElement).length || e.$notifContainer.remove()
                }).trigger("WordpressUlikeRemoveNotification")
            }, 8e3)
        }
    }), s.fn[n] = function (e) {
        return this.each(function () {
            new l(this, e)
        })
    }
}(jQuery, window, document),
    function (n, e, s, t) {
        "use strict";
        var a = "WordpressUlike",
            i = (n(e), n(s)),
            l = {
                ID: 0,
                nonce: 0,
                type: "",
                likeStatus: 0,
                counterSelector: ".count-box",
                generalSelector: ".wp_ulike_general_class",
                buttonSelector: ".wp_ulike_btn",
                likersSelector: ".wp_ulike_likers_wrapper"
            },
            o = {
                "ulike-id": "ID",
                "ulike-nonce": "nonce",
                "ulike-type": "type",
                "ulike-status": "likeStatus"
            };

        function r(e, t) {
            for (var s in this.element = e, this.$element = n(e), this.settings = n.extend({}, l, t), this._defaults = l, this._name = a, this._refreshTheLikers = !1, this.buttonElement = this.$element.find(this.settings.buttonSelector), this.generalElement = this.$element.find(this.settings.generalSelector), this.counterElement = this.generalElement.find(this.settings.counterSelector), o) {
                var i = this.buttonElement.data(s);
                void 0 !== i && (this.settings[o[s]] = i)
            }
            this.init()
        }
        n.extend(r.prototype, {
            init: function () {
                this.buttonElement.click(this._initLike.bind(this)), this.generalElement.hover(this._updateLikers.bind(this))
            },
            _ajax: function (e, t) {
                n.ajax({
                    url: wp_ulike_params.ajax_url,
                    type: "POST",
                    cache: !1,
                    dataType: "json",
                    data: e
                }).done(t)
            },
            _initLike: function (e) {
                e.stopPropagation(), this._updateSameButtons(), this.buttonElement.prop("disabled", !0), i.trigger("WordpressUlikeLoading", this.element), this.generalElement.addClass("wp_ulike_is_loading"), this._ajax({
                    action: "wp_ulike_process",
                    id: this.settings.ID,
                    nonce: this.settings.nonce,
                    status: this.settings.likeStatus,
                    type: this.settings.type
                }, function (e) {
                    this.generalElement.removeClass("wp_ulike_is_loading"), e.success ? this._updateMarkup(e) : this._sendNotification("error", e.data), this.buttonElement.prop("disabled", !1), i.trigger("WordpressUlikeUpdated", this.element)
                }.bind(this))
            },
            _updateMarkup: function (e) {
                switch (this.settings.likeStatus) {
                    case 1:
                        this.buttonElement.attr("data-ulike-status", 4), this.settings.likeStatus = 4, this.generalElement.addClass("wp_ulike_is_liked").removeClass("wp_ulike_is_not_liked"), this.generalElement.children().first().addClass("wp_ulike_click_is_disabled"), this.counterElement.text(e.data.data), this._controlActions("success", e.data.message, e.data.btnText, 4), this._refreshTheLikers = !0;
                        break;
                    case 2:
                        this.buttonElement.attr("data-ulike-status", 3), this.settings.likeStatus = 3, this.generalElement.addClass("wp_ulike_is_unliked").removeClass("wp_ulike_is_liked"), this.counterElement.text(e.data.data), this._controlActions("error", e.data.message, e.data.btnText, 3), this._refreshTheLikers = !0;
                        break;
                    case 3:
                        this.buttonElement.attr("data-ulike-status", 2), this.settings.likeStatus = 2, this.generalElement.addClass("wp_ulike_is_liked").removeClass("wp_ulike_is_unliked"), this.counterElement.text(e.data.data), this._controlActions("success", e.data.message, e.data.btnText, 2), this._refreshTheLikers = !0;
                        break;
                    case 4:
                        this._controlActions("info", e.data.message, e.data.btnText, 4), this.generalElement.children().first().addClass("wp_ulike_click_is_disabled");
                        break;
                    default:
                        this._controlActions("warning", e.data.message, e.data.btnText, 0)
                }
                this._refreshTheLikers && this._updateLikers()
            },
            _updateLikers: function () {
                this.likersElement = this._getLikersElement(), this.likersElement.length && !this._refreshTheLikers || (this.generalElement.addClass("wp_ulike_is_getting_likers_list"), this._ajax({
                    action: "wp_ulike_get_likers",
                    id: this.settings.ID,
                    nonce: this.settings.nonce,
                    type: this.settings.type,
                    refresh: this._refreshTheLikers ? 1 : 0
                }, function (e) {
                    this.generalElement.removeClass("wp_ulike_is_getting_likers_list"), e.success && (this.likersElement.length || (this.likersElement = n("<div>", {
                        class: e.data.class
                    }).appendTo(this.$element)), e.data.template ? this.likersElement.show().html(e.data.template) : this.likersElement.hide()), this._refreshTheLikers = !1
                }.bind(this)))
            },
            _updateSameButtons: function () {
                this.sameButtons = i.find(".wp_" + this.settings.type.toLowerCase() + "_" + this.settings.ID), 1 < this.sameButtons.length && (this.buttonElement = this.sameButtons, this.generalElement = this.buttonElement.closest(this.settings.generalSelector), this.counterElement = this.generalElement.find(this.settings.counterSelector))
            },
            _getLikersElement: function () {
                return 1 < this.generalElement.length ? this.generalElement.next(this.settings.likersSelector) : this.$element.find(this.settings.likersSelector)
            },
            _controlActions: function (e, t, s, i) {
                this.buttonElement.hasClass("wp_ulike_put_image") ? 3 !== i && 2 !== i || this.buttonElement.toggleClass("image-unlike") : this.buttonElement.hasClass("wp_ulike_put_text") && this.buttonElement.find("span").html(s), this._sendNotification(e, t)
            },
            _sendNotification: function (e, t) {
                "1" === wp_ulike_params.notifications && n(s.body).WordpressUlikeNotifications({
                    messageType: e,
                    messageText: t
                })
            }
        }), n.fn[a] = function (e) {
            return this.each(function () {
                n.data(this, "plugin_" + a) || n.data(this, "plugin_" + a, new r(this, e))
            })
        }
    }(jQuery, window, document),
    function (t) {
        t(function () {
            t(this).bind("DOMNodeInserted", function (e) {
                t(".wpulike").WordpressUlike()
            })
        }), t(".wpulike").WordpressUlike()
    }(jQuery);
/*!
 * Bootstrap v4.1.1 (https://getbootstrap.com/)
 * Copyright 2011-2018 The Bootstrap Authors (https://github.com/twbs/bootstrap/graphs/contributors)
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 */
! function (t, e) {
    "object" == typeof exports && "undefined" != typeof module ? e(exports, require("jquery")) : "function" == typeof define && define.amd ? define(["exports", "jquery"], e) : e(t.bootstrap = {}, t.jQuery)
}(this, function (t, e) {
    "use strict";

    function i(t, e) {
        for (var n = 0; n < e.length; n++) {
            var i = e[n];
            i.enumerable = i.enumerable || !1, i.configurable = !0, "value" in i && (i.writable = !0), Object.defineProperty(t, i.key, i)
        }
    }

    function s(t, e, n) {
        return e && i(t.prototype, e), n && i(t, n), t
    }

    function c(r) {
        for (var t = 1; t < arguments.length; t++) {
            var o = null != arguments[t] ? arguments[t] : {},
                e = Object.keys(o);
            "function" == typeof Object.getOwnPropertySymbols && (e = e.concat(Object.getOwnPropertySymbols(o).filter(function (t) {
                return Object.getOwnPropertyDescriptor(o, t).enumerable
            }))), e.forEach(function (t) {
                var e, n, i;
                e = r, i = o[n = t], n in e ? Object.defineProperty(e, n, {
                    value: i,
                    enumerable: !0,
                    configurable: !0,
                    writable: !0
                }) : e[n] = i
            })
        }
        return r
    }
    for (var r, n, o, a, l, f, h, u, d, p, g, m, _, v, E, y, b, T, C, w, I, D, A, S, O, N, k, L, P, x, j, M, R, H, W, F, U, B, K, V, Q, Y, G, q, z, X, J, Z, $, tt, et, nt, it, rt, ot, st, at, lt, ct, ft, ht, ut, dt, pt, gt = function (i) {
        var e = "transitionend";

        function t(t) {
            var e = this,
                n = !1;
            return i(this).one(l.TRANSITION_END, function () {
                n = !0
            }), setTimeout(function () {
                n || l.triggerTransitionEnd(e)
            }, t), this
        }
        var l = {
            TRANSITION_END: "bsTransitionEnd",
            getUID: function (t) {
                for (; t += ~~(1e6 * Math.random()), document.getElementById(t););
                return t
            },
            getSelectorFromElement: function (t) {
                var e = t.getAttribute("data-target");
                e && "#" !== e || (e = t.getAttribute("href") || "");
                try {
                    return 0 < i(document).find(e).length ? e : null
                } catch (t) {
                    return null
                }
            },
            getTransitionDurationFromElement: function (t) {
                if (!t) return 0;
                var e = i(t).css("transition-duration");
                return parseFloat(e) ? (e = e.split(",")[0], 1e3 * parseFloat(e)) : 0
            },
            reflow: function (t) {
                return t.offsetHeight
            },
            triggerTransitionEnd: function (t) {
                i(t).trigger(e)
            },
            supportsTransitionEnd: function () {
                return Boolean(e)
            },
            isElement: function (t) {
                return (t[0] || t).nodeType
            },
            typeCheckConfig: function (t, e, n) {
                for (var i in n)
                    if (Object.prototype.hasOwnProperty.call(n, i)) {
                        var r = n[i],
                            o = e[i],
                            s = o && l.isElement(o) ? "element" : (a = o, {}.toString.call(a).match(/\s([a-z]+)/i)[1].toLowerCase());
                        if (!new RegExp(r).test(s)) throw new Error(t.toUpperCase() + ': Option "' + i + '" provided type "' + s + '" but expected type "' + r + '".')
                    }
                var a
            }
        };
        return i.fn.emulateTransitionEnd = t, i.event.special[l.TRANSITION_END] = {
            bindType: e,
            delegateType: e,
            handle: function (t) {
                if (i(t.target).is(this)) return t.handleObj.handler.apply(this, arguments)
            }
        }, l
    }(e = e && e.hasOwnProperty("default") ? e.default : e), mt = (n = "alert", a = "." + (o = "bs.alert"), l = (r = e).fn[n], f = {
        CLOSE: "close" + a,
        CLOSED: "closed" + a,
        CLICK_DATA_API: "click" + a + ".data-api"
    }, h = "alert", u = "fade", d = "show", p = function () {
        function i(t) {
            this._element = t
        }
        var t = i.prototype;
        return t.close = function (t) {
            var e = this._element;
            t && (e = this._getRootElement(t)), this._triggerCloseEvent(e).isDefaultPrevented() || this._removeElement(e)
        }, t.dispose = function () {
            r.removeData(this._element, o), this._element = null
        }, t._getRootElement = function (t) {
            var e = gt.getSelectorFromElement(t),
                n = !1;
            return e && (n = r(e)[0]), n || (n = r(t).closest("." + h)[0]), n
        }, t._triggerCloseEvent = function (t) {
            var e = r.Event(f.CLOSE);
            return r(t).trigger(e), e
        }, t._removeElement = function (e) {
            var n = this;
            if (r(e).removeClass(d), r(e).hasClass(u)) {
                var t = gt.getTransitionDurationFromElement(e);
                r(e).one(gt.TRANSITION_END, function (t) {
                    return n._destroyElement(e, t)
                }).emulateTransitionEnd(t)
            } else this._destroyElement(e)
        }, t._destroyElement = function (t) {
            r(t).detach().trigger(f.CLOSED).remove()
        }, i._jQueryInterface = function (n) {
            return this.each(function () {
                var t = r(this),
                    e = t.data(o);
                e || (e = new i(this), t.data(o, e)), "close" === n && e[n](this)
            })
        }, i._handleDismiss = function (e) {
            return function (t) {
                t && t.preventDefault(), e.close(this)
            }
        }, s(i, null, [{
            key: "VERSION",
            get: function () {
                return "4.1.1"
            }
        }]), i
    }(), r(document).on(f.CLICK_DATA_API, '[data-dismiss="alert"]', p._handleDismiss(new p)), r.fn[n] = p._jQueryInterface, r.fn[n].Constructor = p, r.fn[n].noConflict = function () {
        return r.fn[n] = l, p._jQueryInterface
    }, p), _t = (m = "button", v = "." + (_ = "bs.button"), E = ".data-api", y = (g = e).fn[m], b = "active", T = "btn", w = '[data-toggle^="button"]', I = '[data-toggle="buttons"]', D = "input", A = ".active", S = ".btn", O = {
        CLICK_DATA_API: "click" + v + E,
        FOCUS_BLUR_DATA_API: (C = "focus") + v + E + " blur" + v + E
    }, N = function () {
        function n(t) {
            this._element = t
        }
        var t = n.prototype;
        return t.toggle = function () {
            var t = !0,
                e = !0,
                n = g(this._element).closest(I)[0];
            if (n) {
                var i = g(this._element).find(D)[0];
                if (i) {
                    if ("radio" === i.type)
                        if (i.checked && g(this._element).hasClass(b)) t = !1;
                        else {
                            var r = g(n).find(A)[0];
                            r && g(r).removeClass(b)
                        }
                    if (t) {
                        if (i.hasAttribute("disabled") || n.hasAttribute("disabled") || i.classList.contains("disabled") || n.classList.contains("disabled")) return;
                        i.checked = !g(this._element).hasClass(b), g(i).trigger("change")
                    }
                    i.focus(), e = !1
                }
            }
            e && this._element.setAttribute("aria-pressed", !g(this._element).hasClass(b)), t && g(this._element).toggleClass(b)
        }, t.dispose = function () {
            g.removeData(this._element, _), this._element = null
        }, n._jQueryInterface = function (e) {
            return this.each(function () {
                var t = g(this).data(_);
                t || (t = new n(this), g(this).data(_, t)), "toggle" === e && t[e]()
            })
        }, s(n, null, [{
            key: "VERSION",
            get: function () {
                return "4.1.1"
            }
        }]), n
    }(), g(document).on(O.CLICK_DATA_API, w, function (t) {
        t.preventDefault();
        var e = t.target;
        g(e).hasClass(T) || (e = g(e).closest(S)), N._jQueryInterface.call(g(e), "toggle")
    }).on(O.FOCUS_BLUR_DATA_API, w, function (t) {
        var e = g(t.target).closest(S)[0];
        g(e).toggleClass(C, /^focus(in)?$/.test(t.type))
    }), g.fn[m] = N._jQueryInterface, g.fn[m].Constructor = N, g.fn[m].noConflict = function () {
        return g.fn[m] = y, N._jQueryInterface
    }, N), vt = (L = "carousel", x = "." + (P = "bs.carousel"), j = ".data-api", M = (k = e).fn[L], R = {
        interval: 5e3,
        keyboard: !0,
        slide: !1,
        pause: "hover",
        wrap: !0
    }, H = {
        interval: "(number|boolean)",
        keyboard: "boolean",
        slide: "(boolean|string)",
        pause: "(string|boolean)",
        wrap: "boolean"
    }, W = "next", F = "prev", U = "left", B = "right", K = {
        SLIDE: "slide" + x,
        SLID: "slid" + x,
        KEYDOWN: "keydown" + x,
        MOUSEENTER: "mouseenter" + x,
        MOUSELEAVE: "mouseleave" + x,
        TOUCHEND: "touchend" + x,
        LOAD_DATA_API: "load" + x + j,
        CLICK_DATA_API: "click" + x + j
    }, V = "carousel", Q = "active", Y = "slide", G = "carousel-item-right", q = "carousel-item-left", z = "carousel-item-next", X = "carousel-item-prev", J = {
        ACTIVE: ".active",
        ACTIVE_ITEM: ".active.carousel-item",
        ITEM: ".carousel-item",
        NEXT_PREV: ".carousel-item-next, .carousel-item-prev",
        INDICATORS: ".carousel-indicators",
        DATA_SLIDE: "[data-slide], [data-slide-to]",
        DATA_RIDE: '[data-ride="carousel"]'
    }, Z = function () {
        function o(t, e) {
            this._items = null, this._interval = null, this._activeElement = null, this._isPaused = !1, this._isSliding = !1, this.touchTimeout = null, this._config = this._getConfig(e), this._element = k(t)[0], this._indicatorsElement = k(this._element).find(J.INDICATORS)[0], this._addEventListeners()
        }
        var t = o.prototype;
        return t.next = function () {
            this._isSliding || this._slide(W)
        }, t.nextWhenVisible = function () {
            !document.hidden && k(this._element).is(":visible") && "hidden" !== k(this._element).css("visibility") && this.next()
        }, t.prev = function () {
            this._isSliding || this._slide(F)
        }, t.pause = function (t) {
            t || (this._isPaused = !0), k(this._element).find(J.NEXT_PREV)[0] && (gt.triggerTransitionEnd(this._element), this.cycle(!0)), clearInterval(this._interval), this._interval = null
        }, t.cycle = function (t) {
            t || (this._isPaused = !1), this._interval && (clearInterval(this._interval), this._interval = null), this._config.interval && !this._isPaused && (this._interval = setInterval((document.visibilityState ? this.nextWhenVisible : this.next).bind(this), this._config.interval))
        }, t.to = function (t) {
            var e = this;
            this._activeElement = k(this._element).find(J.ACTIVE_ITEM)[0];
            var n = this._getItemIndex(this._activeElement);
            if (!(t > this._items.length - 1 || t < 0))
                if (this._isSliding) k(this._element).one(K.SLID, function () {
                    return e.to(t)
                });
                else {
                    if (n === t) return this.pause(), void this.cycle();
                    var i = n < t ? W : F;
                    this._slide(i, this._items[t])
                }
        }, t.dispose = function () {
            k(this._element).off(x), k.removeData(this._element, P), this._items = null, this._config = null, this._element = null, this._interval = null, this._isPaused = null, this._isSliding = null, this._activeElement = null, this._indicatorsElement = null
        }, t._getConfig = function (t) {
            return t = c({}, R, t), gt.typeCheckConfig(L, t, H), t
        }, t._addEventListeners = function () {
            var e = this;
            this._config.keyboard && k(this._element).on(K.KEYDOWN, function (t) {
                return e._keydown(t)
            }), "hover" === this._config.pause && (k(this._element).on(K.MOUSEENTER, function (t) {
                return e.pause(t)
            }).on(K.MOUSELEAVE, function (t) {
                return e.cycle(t)
            }), "ontouchstart" in document.documentElement && k(this._element).on(K.TOUCHEND, function () {
                e.pause(), e.touchTimeout && clearTimeout(e.touchTimeout), e.touchTimeout = setTimeout(function (t) {
                    return e.cycle(t)
                }, 500 + e._config.interval)
            }))
        }, t._keydown = function (t) {
            if (!/input|textarea/i.test(t.target.tagName)) switch (t.which) {
                case 37:
                    t.preventDefault(), this.prev();
                    break;
                case 39:
                    t.preventDefault(), this.next()
            }
        }, t._getItemIndex = function (t) {
            return this._items = k.makeArray(k(t).parent().find(J.ITEM)), this._items.indexOf(t)
        }, t._getItemByDirection = function (t, e) {
            var n = t === W,
                i = t === F,
                r = this._getItemIndex(e),
                o = this._items.length - 1;
            if ((i && 0 === r || n && r === o) && !this._config.wrap) return e;
            var s = (r + (t === F ? -1 : 1)) % this._items.length;
            return -1 === s ? this._items[this._items.length - 1] : this._items[s]
        }, t._triggerSlideEvent = function (t, e) {
            var n = this._getItemIndex(t),
                i = this._getItemIndex(k(this._element).find(J.ACTIVE_ITEM)[0]),
                r = k.Event(K.SLIDE, {
                    relatedTarget: t,
                    direction: e,
                    from: i,
                    to: n
                });
            return k(this._element).trigger(r), r
        }, t._setActiveIndicatorElement = function (t) {
            if (this._indicatorsElement) {
                k(this._indicatorsElement).find(J.ACTIVE).removeClass(Q);
                var e = this._indicatorsElement.children[this._getItemIndex(t)];
                e && k(e).addClass(Q)
            }
        }, t._slide = function (t, e) {
            var n, i, r, o = this,
                s = k(this._element).find(J.ACTIVE_ITEM)[0],
                a = this._getItemIndex(s),
                l = e || s && this._getItemByDirection(t, s),
                c = this._getItemIndex(l),
                f = Boolean(this._interval);
            if (t === W ? (n = q, i = z, r = U) : (n = G, i = X, r = B), l && k(l).hasClass(Q)) this._isSliding = !1;
            else if (!this._triggerSlideEvent(l, r).isDefaultPrevented() && s && l) {
                this._isSliding = !0, f && this.pause(), this._setActiveIndicatorElement(l);
                var h = k.Event(K.SLID, {
                    relatedTarget: l,
                    direction: r,
                    from: a,
                    to: c
                });
                if (k(this._element).hasClass(Y)) {
                    k(l).addClass(i), gt.reflow(l), k(s).addClass(n), k(l).addClass(n);
                    var u = gt.getTransitionDurationFromElement(s);
                    k(s).one(gt.TRANSITION_END, function () {
                        k(l).removeClass(n + " " + i).addClass(Q), k(s).removeClass(Q + " " + i + " " + n), o._isSliding = !1, setTimeout(function () {
                            return k(o._element).trigger(h)
                        }, 0)
                    }).emulateTransitionEnd(u)
                } else k(s).removeClass(Q), k(l).addClass(Q), this._isSliding = !1, k(this._element).trigger(h);
                f && this.cycle()
            }
        }, o._jQueryInterface = function (i) {
            return this.each(function () {
                var t = k(this).data(P),
                    e = c({}, R, k(this).data());
                "object" == typeof i && (e = c({}, e, i));
                var n = "string" == typeof i ? i : e.slide;
                if (t || (t = new o(this, e), k(this).data(P, t)), "number" == typeof i) t.to(i);
                else if ("string" == typeof n) {
                    if ("undefined" == typeof t[n]) throw new TypeError('No method named "' + n + '"');
                    t[n]()
                } else e.interval && (t.pause(), t.cycle())
            })
        }, o._dataApiClickHandler = function (t) {
            var e = gt.getSelectorFromElement(this);
            if (e) {
                var n = k(e)[0];
                if (n && k(n).hasClass(V)) {
                    var i = c({}, k(n).data(), k(this).data()),
                        r = this.getAttribute("data-slide-to");
                    r && (i.interval = !1), o._jQueryInterface.call(k(n), i), r && k(n).data(P).to(r), t.preventDefault()
                }
            }
        }, s(o, null, [{
            key: "VERSION",
            get: function () {
                return "4.1.1"
            }
        }, {
            key: "Default",
            get: function () {
                return R
            }
        }]), o
    }(), k(document).on(K.CLICK_DATA_API, J.DATA_SLIDE, Z._dataApiClickHandler), k(window).on(K.LOAD_DATA_API, function () {
        k(J.DATA_RIDE).each(function () {
            var t = k(this);
            Z._jQueryInterface.call(t, t.data())
        })
    }), k.fn[L] = Z._jQueryInterface, k.fn[L].Constructor = Z, k.fn[L].noConflict = function () {
        return k.fn[L] = M, Z._jQueryInterface
    }, Z), Et = (tt = "collapse", nt = "." + (et = "bs.collapse"), it = ($ = e).fn[tt], rt = {
        toggle: !0,
        parent: ""
    }, ot = {
        toggle: "boolean",
        parent: "(string|element)"
    }, st = {
        SHOW: "show" + nt,
        SHOWN: "shown" + nt,
        HIDE: "hide" + nt,
        HIDDEN: "hidden" + nt,
        CLICK_DATA_API: "click" + nt + ".data-api"
    }, at = "show", lt = "collapse", ct = "collapsing", ft = "collapsed", ht = "width", ut = "height", dt = {
        ACTIVES: ".show, .collapsing",
        DATA_TOGGLE: '[data-toggle="collapse"]'
    }, pt = function () {
        function a(t, e) {
            this._isTransitioning = !1, this._element = t, this._config = this._getConfig(e), this._triggerArray = $.makeArray($('[data-toggle="collapse"][href="#' + t.id + '"],[data-toggle="collapse"][data-target="#' + t.id + '"]'));
            for (var n = $(dt.DATA_TOGGLE), i = 0; i < n.length; i++) {
                var r = n[i],
                    o = gt.getSelectorFromElement(r);
                null !== o && 0 < $(o).filter(t).length && (this._selector = o, this._triggerArray.push(r))
            }
            this._parent = this._config.parent ? this._getParent() : null, this._config.parent || this._addAriaAndCollapsedClass(this._element, this._triggerArray), this._config.toggle && this.toggle()
        }
        var t = a.prototype;
        return t.toggle = function () {
            $(this._element).hasClass(at) ? this.hide() : this.show()
        }, t.show = function () {
            var t, e, n = this;
            if (!this._isTransitioning && !$(this._element).hasClass(at) && (this._parent && 0 === (t = $.makeArray($(this._parent).find(dt.ACTIVES).filter('[data-parent="' + this._config.parent + '"]'))).length && (t = null), !(t && (e = $(t).not(this._selector).data(et)) && e._isTransitioning))) {
                var i = $.Event(st.SHOW);
                if ($(this._element).trigger(i), !i.isDefaultPrevented()) {
                    t && (a._jQueryInterface.call($(t).not(this._selector), "hide"), e || $(t).data(et, null));
                    var r = this._getDimension();
                    $(this._element).removeClass(lt).addClass(ct), (this._element.style[r] = 0) < this._triggerArray.length && $(this._triggerArray).removeClass(ft).attr("aria-expanded", !0), this.setTransitioning(!0);
                    var o = "scroll" + (r[0].toUpperCase() + r.slice(1)),
                        s = gt.getTransitionDurationFromElement(this._element);
                    $(this._element).one(gt.TRANSITION_END, function () {
                        $(n._element).removeClass(ct).addClass(lt).addClass(at), n._element.style[r] = "", n.setTransitioning(!1), $(n._element).trigger(st.SHOWN)
                    }).emulateTransitionEnd(s), this._element.style[r] = this._element[o] + "px"
                }
            }
        }, t.hide = function () {
            var t = this;
            if (!this._isTransitioning && $(this._element).hasClass(at)) {
                var e = $.Event(st.HIDE);
                if ($(this._element).trigger(e), !e.isDefaultPrevented()) {
                    var n = this._getDimension();
                    if (this._element.style[n] = this._element.getBoundingClientRect()[n] + "px", gt.reflow(this._element), $(this._element).addClass(ct).removeClass(lt).removeClass(at), 0 < this._triggerArray.length)
                        for (var i = 0; i < this._triggerArray.length; i++) {
                            var r = this._triggerArray[i],
                                o = gt.getSelectorFromElement(r);
                            if (null !== o) $(o).hasClass(at) || $(r).addClass(ft).attr("aria-expanded", !1)
                        }
                    this.setTransitioning(!0);
                    this._element.style[n] = "";
                    var s = gt.getTransitionDurationFromElement(this._element);
                    $(this._element).one(gt.TRANSITION_END, function () {
                        t.setTransitioning(!1), $(t._element).removeClass(ct).addClass(lt).trigger(st.HIDDEN)
                    }).emulateTransitionEnd(s)
                }
            }
        }, t.setTransitioning = function (t) {
            this._isTransitioning = t
        }, t.dispose = function () {
            $.removeData(this._element, et), this._config = null, this._parent = null, this._element = null, this._triggerArray = null, this._isTransitioning = null
        }, t._getConfig = function (t) {
            return (t = c({}, rt, t)).toggle = Boolean(t.toggle), gt.typeCheckConfig(tt, t, ot), t
        }, t._getDimension = function () {
            return $(this._element).hasClass(ht) ? ht : ut
        }, t._getParent = function () {
            var n = this,
                t = null;
            gt.isElement(this._config.parent) ? (t = this._config.parent, "undefined" != typeof this._config.parent.jquery && (t = this._config.parent[0])) : t = $(this._config.parent)[0];
            var e = '[data-toggle="collapse"][data-parent="' + this._config.parent + '"]';
            return $(t).find(e).each(function (t, e) {
                n._addAriaAndCollapsedClass(a._getTargetFromElement(e), [e])
            }), t
        }, t._addAriaAndCollapsedClass = function (t, e) {
            if (t) {
                var n = $(t).hasClass(at);
                0 < e.length && $(e).toggleClass(ft, !n).attr("aria-expanded", n)
            }
        }, a._getTargetFromElement = function (t) {
            var e = gt.getSelectorFromElement(t);
            return e ? $(e)[0] : null
        }, a._jQueryInterface = function (i) {
            return this.each(function () {
                var t = $(this),
                    e = t.data(et),
                    n = c({}, rt, t.data(), "object" == typeof i && i ? i : {});
                if (!e && n.toggle && /show|hide/.test(i) && (n.toggle = !1), e || (e = new a(this, n), t.data(et, e)), "string" == typeof i) {
                    if ("undefined" == typeof e[i]) throw new TypeError('No method named "' + i + '"');
                    e[i]()
                }
            })
        }, s(a, null, [{
            key: "VERSION",
            get: function () {
                return "4.1.1"
            }
        }, {
            key: "Default",
            get: function () {
                return rt
            }
        }]), a
    }(), $(document).on(st.CLICK_DATA_API, dt.DATA_TOGGLE, function (t) {
        "A" === t.currentTarget.tagName && t.preventDefault();
        var n = $(this),
            e = gt.getSelectorFromElement(this);
        $(e).each(function () {
            var t = $(this),
                e = t.data(et) ? "toggle" : n.data();
            pt._jQueryInterface.call(t, e)
        })
    }), $.fn[tt] = pt._jQueryInterface, $.fn[tt].Constructor = pt, $.fn[tt].noConflict = function () {
        return $.fn[tt] = it, pt._jQueryInterface
    }, pt), yt = "undefined" != typeof window && "undefined" != typeof document, bt = ["Edge", "Trident", "Firefox"], Tt = 0, Ct = 0; Ct < bt.length; Ct += 1)
        if (yt && 0 <= navigator.userAgent.indexOf(bt[Ct])) {
            Tt = 1;
            break
        }
    var wt = yt && window.Promise ? function (t) {
        var e = !1;
        return function () {
            e || (e = !0, window.Promise.resolve().then(function () {
                e = !1, t()
            }))
        }
    } : function (t) {
        var e = !1;
        return function () {
            e || (e = !0, setTimeout(function () {
                e = !1, t()
            }, Tt))
        }
    };

    function It(t) {
        return t && "[object Function]" === {}.toString.call(t)
    }

    function Dt(t, e) {
        if (1 !== t.nodeType) return [];
        var n = getComputedStyle(t, null);
        return e ? n[e] : n
    }

    function At(t) {
        return "HTML" === t.nodeName ? t : t.parentNode || t.host
    }

    function St(t) {
        if (!t) return document.body;
        switch (t.nodeName) {
            case "HTML":
            case "BODY":
                return t.ownerDocument.body;
            case "#document":
                return t.body
        }
        var e = Dt(t),
            n = e.overflow,
            i = e.overflowX,
            r = e.overflowY;
        return /(auto|scroll|overlay)/.test(n + r + i) ? t : St(At(t))
    }
    var Ot = yt && !(!window.MSInputMethodContext || !document.documentMode),
        Nt = yt && /MSIE 10/.test(navigator.userAgent);

    function kt(t) {
        return 11 === t ? Ot : 10 === t ? Nt : Ot || Nt
    }

    function Lt(t) {
        if (!t) return document.documentElement;
        for (var e = kt(10) ? document.body : null, n = t.offsetParent; n === e && t.nextElementSibling;) n = (t = t.nextElementSibling).offsetParent;
        var i = n && n.nodeName;
        return i && "BODY" !== i && "HTML" !== i ? -1 !== ["TD", "TABLE"].indexOf(n.nodeName) && "static" === Dt(n, "position") ? Lt(n) : n : t ? t.ownerDocument.documentElement : document.documentElement
    }

    function Pt(t) {
        return null !== t.parentNode ? Pt(t.parentNode) : t
    }

    function xt(t, e) {
        if (!(t && t.nodeType && e && e.nodeType)) return document.documentElement;
        var n = t.compareDocumentPosition(e) & Node.DOCUMENT_POSITION_FOLLOWING,
            i = n ? t : e,
            r = n ? e : t,
            o = document.createRange();
        o.setStart(i, 0), o.setEnd(r, 0);
        var s, a, l = o.commonAncestorContainer;
        if (t !== l && e !== l || i.contains(r)) return "BODY" === (a = (s = l).nodeName) || "HTML" !== a && Lt(s.firstElementChild) !== s ? Lt(l) : l;
        var c = Pt(t);
        return c.host ? xt(c.host, e) : xt(t, Pt(e).host)
    }

    function jt(t) {
        var e = "top" === (1 < arguments.length && void 0 !== arguments[1] ? arguments[1] : "top") ? "scrollTop" : "scrollLeft",
            n = t.nodeName;
        if ("BODY" === n || "HTML" === n) {
            var i = t.ownerDocument.documentElement;
            return (t.ownerDocument.scrollingElement || i)[e]
        }
        return t[e]
    }

    function Mt(t, e) {
        var n = "x" === e ? "Left" : "Top",
            i = "Left" === n ? "Right" : "Bottom";
        return parseFloat(t["border" + n + "Width"], 10) + parseFloat(t["border" + i + "Width"], 10)
    }

    function Rt(t, e, n, i) {
        return Math.max(e["offset" + t], e["scroll" + t], n["client" + t], n["offset" + t], n["scroll" + t], kt(10) ? n["offset" + t] + i["margin" + ("Height" === t ? "Top" : "Left")] + i["margin" + ("Height" === t ? "Bottom" : "Right")] : 0)
    }

    function Ht() {
        var t = document.body,
            e = document.documentElement,
            n = kt(10) && getComputedStyle(e);
        return {
            height: Rt("Height", t, e, n),
            width: Rt("Width", t, e, n)
        }
    }
    var Wt = function (t, e) {
        if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
    },
        Ft = function () {
            function i(t, e) {
                for (var n = 0; n < e.length; n++) {
                    var i = e[n];
                    i.enumerable = i.enumerable || !1, i.configurable = !0, "value" in i && (i.writable = !0), Object.defineProperty(t, i.key, i)
                }
            }
            return function (t, e, n) {
                return e && i(t.prototype, e), n && i(t, n), t
            }
        }(),
        Ut = function (t, e, n) {
            return e in t ? Object.defineProperty(t, e, {
                value: n,
                enumerable: !0,
                configurable: !0,
                writable: !0
            }) : t[e] = n, t
        },
        Bt = Object.assign || function (t) {
            for (var e = 1; e < arguments.length; e++) {
                var n = arguments[e];
                for (var i in n) Object.prototype.hasOwnProperty.call(n, i) && (t[i] = n[i])
            }
            return t
        };

    function Kt(t) {
        return Bt({}, t, {
            right: t.left + t.width,
            bottom: t.top + t.height
        })
    }

    function Vt(t) {
        var e = {};
        try {
            if (kt(10)) {
                e = t.getBoundingClientRect();
                var n = jt(t, "top"),
                    i = jt(t, "left");
                e.top += n, e.left += i, e.bottom += n, e.right += i
            } else e = t.getBoundingClientRect()
        } catch (t) { }
        var r = {
            left: e.left,
            top: e.top,
            width: e.right - e.left,
            height: e.bottom - e.top
        },
            o = "HTML" === t.nodeName ? Ht() : {},
            s = o.width || t.clientWidth || r.right - r.left,
            a = o.height || t.clientHeight || r.bottom - r.top,
            l = t.offsetWidth - s,
            c = t.offsetHeight - a;
        if (l || c) {
            var f = Dt(t);
            l -= Mt(f, "x"), c -= Mt(f, "y"), r.width -= l, r.height -= c
        }
        return Kt(r)
    }

    function Qt(t, e) {
        var n = 2 < arguments.length && void 0 !== arguments[2] && arguments[2],
            i = kt(10),
            r = "HTML" === e.nodeName,
            o = Vt(t),
            s = Vt(e),
            a = St(t),
            l = Dt(e),
            c = parseFloat(l.borderTopWidth, 10),
            f = parseFloat(l.borderLeftWidth, 10);
        n && "HTML" === e.nodeName && (s.top = Math.max(s.top, 0), s.left = Math.max(s.left, 0));
        var h = Kt({
            top: o.top - s.top - c,
            left: o.left - s.left - f,
            width: o.width,
            height: o.height
        });
        if (h.marginTop = 0, h.marginLeft = 0, !i && r) {
            var u = parseFloat(l.marginTop, 10),
                d = parseFloat(l.marginLeft, 10);
            h.top -= c - u, h.bottom -= c - u, h.left -= f - d, h.right -= f - d, h.marginTop = u, h.marginLeft = d
        }
        return (i && !n ? e.contains(a) : e === a && "BODY" !== a.nodeName) && (h = function (t, e) {
            var n = 2 < arguments.length && void 0 !== arguments[2] && arguments[2],
                i = jt(e, "top"),
                r = jt(e, "left"),
                o = n ? -1 : 1;
            return t.top += i * o, t.bottom += i * o, t.left += r * o, t.right += r * o, t
        }(h, e)), h
    }

    function Yt(t) {
        if (!t || !t.parentElement || kt()) return document.documentElement;
        for (var e = t.parentElement; e && "none" === Dt(e, "transform");) e = e.parentElement;
        return e || document.documentElement
    }

    function Gt(t, e, n, i) {
        var r = 4 < arguments.length && void 0 !== arguments[4] && arguments[4],
            o = {
                top: 0,
                left: 0
            },
            s = r ? Yt(t) : xt(t, e);
        if ("viewport" === i) o = function (t) {
            var e = 1 < arguments.length && void 0 !== arguments[1] && arguments[1],
                n = t.ownerDocument.documentElement,
                i = Qt(t, n),
                r = Math.max(n.clientWidth, window.innerWidth || 0),
                o = Math.max(n.clientHeight, window.innerHeight || 0),
                s = e ? 0 : jt(n),
                a = e ? 0 : jt(n, "left");
            return Kt({
                top: s - i.top + i.marginTop,
                left: a - i.left + i.marginLeft,
                width: r,
                height: o
            })
        }(s, r);
        else {
            var a = void 0;
            "scrollParent" === i ? "BODY" === (a = St(At(e))).nodeName && (a = t.ownerDocument.documentElement) : a = "window" === i ? t.ownerDocument.documentElement : i;
            var l = Qt(a, s, r);
            if ("HTML" !== a.nodeName || function t(e) {
                var n = e.nodeName;
                return "BODY" !== n && "HTML" !== n && ("fixed" === Dt(e, "position") || t(At(e)))
            }(s)) o = l;
            else {
                var c = Ht(),
                    f = c.height,
                    h = c.width;
                o.top += l.top - l.marginTop, o.bottom = f + l.top, o.left += l.left - l.marginLeft, o.right = h + l.left
            }
        }
        return o.left += n, o.top += n, o.right -= n, o.bottom -= n, o
    }

    function qt(t, e, i, n, r) {
        var o = 5 < arguments.length && void 0 !== arguments[5] ? arguments[5] : 0;
        if (-1 === t.indexOf("auto")) return t;
        var s = Gt(i, n, o, r),
            a = {
                top: {
                    width: s.width,
                    height: e.top - s.top
                },
                right: {
                    width: s.right - e.right,
                    height: s.height
                },
                bottom: {
                    width: s.width,
                    height: s.bottom - e.bottom
                },
                left: {
                    width: e.left - s.left,
                    height: s.height
                }
            },
            l = Object.keys(a).map(function (t) {
                return Bt({
                    key: t
                }, a[t], {
                        area: (e = a[t], e.width * e.height)
                    });
                var e
            }).sort(function (t, e) {
                return e.area - t.area
            }),
            c = l.filter(function (t) {
                var e = t.width,
                    n = t.height;
                return e >= i.clientWidth && n >= i.clientHeight
            }),
            f = 0 < c.length ? c[0].key : l[0].key,
            h = t.split("-")[1];
        return f + (h ? "-" + h : "")
    }

    function zt(t, e, n) {
        var i = 3 < arguments.length && void 0 !== arguments[3] ? arguments[3] : null;
        return Qt(n, i ? Yt(e) : xt(e, n), i)
    }

    function Xt(t) {
        var e = getComputedStyle(t),
            n = parseFloat(e.marginTop) + parseFloat(e.marginBottom),
            i = parseFloat(e.marginLeft) + parseFloat(e.marginRight);
        return {
            width: t.offsetWidth + i,
            height: t.offsetHeight + n
        }
    }

    function Jt(t) {
        var e = {
            left: "right",
            right: "left",
            bottom: "top",
            top: "bottom"
        };
        return t.replace(/left|right|bottom|top/g, function (t) {
            return e[t]
        })
    }

    function Zt(t, e, n) {
        n = n.split("-")[0];
        var i = Xt(t),
            r = {
                width: i.width,
                height: i.height
            },
            o = -1 !== ["right", "left"].indexOf(n),
            s = o ? "top" : "left",
            a = o ? "left" : "top",
            l = o ? "height" : "width",
            c = o ? "width" : "height";
        return r[s] = e[s] + e[l] / 2 - i[l] / 2, r[a] = n === a ? e[a] - i[c] : e[Jt(a)], r
    }

    function $t(t, e) {
        return Array.prototype.find ? t.find(e) : t.filter(e)[0]
    }

    function te(t, n, e) {
        return (void 0 === e ? t : t.slice(0, function (t, e, n) {
            if (Array.prototype.findIndex) return t.findIndex(function (t) {
                return t[e] === n
            });
            var i = $t(t, function (t) {
                return t[e] === n
            });
            return t.indexOf(i)
        }(t, "name", e))).forEach(function (t) {
            t.function && console.warn("`modifier.function` is deprecated, use `modifier.fn`!");
            var e = t.function || t.fn;
            t.enabled && It(e) && (n.offsets.popper = Kt(n.offsets.popper), n.offsets.reference = Kt(n.offsets.reference), n = e(n, t))
        }), n
    }

    function ee(t, n) {
        return t.some(function (t) {
            var e = t.name;
            return t.enabled && e === n
        })
    }

    function ne(t) {
        for (var e = [!1, "ms", "Webkit", "Moz", "O"], n = t.charAt(0).toUpperCase() + t.slice(1), i = 0; i < e.length; i++) {
            var r = e[i],
                o = r ? "" + r + n : t;
            if ("undefined" != typeof document.body.style[o]) return o
        }
        return null
    }

    function ie(t) {
        var e = t.ownerDocument;
        return e ? e.defaultView : window
    }

    function re(t, e, n, i) {
        n.updateBound = i, ie(t).addEventListener("resize", n.updateBound, {
            passive: !0
        });
        var r = St(t);
        return function t(e, n, i, r) {
            var o = "BODY" === e.nodeName,
                s = o ? e.ownerDocument.defaultView : e;
            s.addEventListener(n, i, {
                passive: !0
            }), o || t(St(s.parentNode), n, i, r), r.push(s)
        }(r, "scroll", n.updateBound, n.scrollParents), n.scrollElement = r, n.eventsEnabled = !0, n
    }

    function oe() {
        var t, e;
        this.state.eventsEnabled && (cancelAnimationFrame(this.scheduleUpdate), this.state = (t = this.reference, e = this.state, ie(t).removeEventListener("resize", e.updateBound), e.scrollParents.forEach(function (t) {
            t.removeEventListener("scroll", e.updateBound)
        }), e.updateBound = null, e.scrollParents = [], e.scrollElement = null, e.eventsEnabled = !1, e))
    }

    function se(t) {
        return "" !== t && !isNaN(parseFloat(t)) && isFinite(t)
    }

    function ae(n, i) {
        Object.keys(i).forEach(function (t) {
            var e = ""; - 1 !== ["width", "height", "top", "right", "bottom", "left"].indexOf(t) && se(i[t]) && (e = "px"), n.style[t] = i[t] + e
        })
    }

    function le(t, e, n) {
        var i = $t(t, function (t) {
            return t.name === e
        }),
            r = !!i && t.some(function (t) {
                return t.name === n && t.enabled && t.order < i.order
            });
        if (!r) {
            var o = "`" + e + "`",
                s = "`" + n + "`";
            console.warn(s + " modifier is required by " + o + " modifier in order to work, be sure to include it before " + o + "!")
        }
        return r
    }
    var ce = ["auto-start", "auto", "auto-end", "top-start", "top", "top-end", "right-start", "right", "right-end", "bottom-end", "bottom", "bottom-start", "left-end", "left", "left-start"],
        fe = ce.slice(3);

    function he(t) {
        var e = 1 < arguments.length && void 0 !== arguments[1] && arguments[1],
            n = fe.indexOf(t),
            i = fe.slice(n + 1).concat(fe.slice(0, n));
        return e ? i.reverse() : i
    }
    var ue = {
        FLIP: "flip",
        CLOCKWISE: "clockwise",
        COUNTERCLOCKWISE: "counterclockwise"
    };

    function de(t, r, o, e) {
        var s = [0, 0],
            a = -1 !== ["right", "left"].indexOf(e),
            n = t.split(/(\+|\-)/).map(function (t) {
                return t.trim()
            }),
            i = n.indexOf($t(n, function (t) {
                return -1 !== t.search(/,|\s/)
            }));
        n[i] && -1 === n[i].indexOf(",") && console.warn("Offsets separated by white space(s) are deprecated, use a comma (,) instead.");
        var l = /\s*,\s*|\s+/,
            c = -1 !== i ? [n.slice(0, i).concat([n[i].split(l)[0]]), [n[i].split(l)[1]].concat(n.slice(i + 1))] : [n];
        return (c = c.map(function (t, e) {
            var n = (1 === e ? !a : a) ? "height" : "width",
                i = !1;
            return t.reduce(function (t, e) {
                return "" === t[t.length - 1] && -1 !== ["+", "-"].indexOf(e) ? (t[t.length - 1] = e, i = !0, t) : i ? (t[t.length - 1] += e, i = !1, t) : t.concat(e)
            }, []).map(function (t) {
                return function (t, e, n, i) {
                    var r = t.match(/((?:\-|\+)?\d*\.?\d*)(.*)/),
                        o = +r[1],
                        s = r[2];
                    if (!o) return t;
                    if (0 === s.indexOf("%")) {
                        var a = void 0;
                        switch (s) {
                            case "%p":
                                a = n;
                                break;
                            case "%":
                            case "%r":
                            default:
                                a = i
                        }
                        return Kt(a)[e] / 100 * o
                    }
                    if ("vh" === s || "vw" === s) return ("vh" === s ? Math.max(document.documentElement.clientHeight, window.innerHeight || 0) : Math.max(document.documentElement.clientWidth, window.innerWidth || 0)) / 100 * o;
                    return o
                }(t, n, r, o)
            })
        })).forEach(function (n, i) {
            n.forEach(function (t, e) {
                se(t) && (s[i] += t * ("-" === n[e - 1] ? -1 : 1))
            })
        }), s
    }
    var pe = {
        placement: "bottom",
        positionFixed: !1,
        eventsEnabled: !0,
        removeOnDestroy: !1,
        onCreate: function () { },
        onUpdate: function () { },
        modifiers: {
            shift: {
                order: 100,
                enabled: !0,
                fn: function (t) {
                    var e = t.placement,
                        n = e.split("-")[0],
                        i = e.split("-")[1];
                    if (i) {
                        var r = t.offsets,
                            o = r.reference,
                            s = r.popper,
                            a = -1 !== ["bottom", "top"].indexOf(n),
                            l = a ? "left" : "top",
                            c = a ? "width" : "height",
                            f = {
                                start: Ut({}, l, o[l]),
                                end: Ut({}, l, o[l] + o[c] - s[c])
                            };
                        t.offsets.popper = Bt({}, s, f[i])
                    }
                    return t
                }
            },
            offset: {
                order: 200,
                enabled: !0,
                fn: function (t, e) {
                    var n = e.offset,
                        i = t.placement,
                        r = t.offsets,
                        o = r.popper,
                        s = r.reference,
                        a = i.split("-")[0],
                        l = void 0;
                    return l = se(+n) ? [+n, 0] : de(n, o, s, a), "left" === a ? (o.top += l[0], o.left -= l[1]) : "right" === a ? (o.top += l[0], o.left += l[1]) : "top" === a ? (o.left += l[0], o.top -= l[1]) : "bottom" === a && (o.left += l[0], o.top += l[1]), t.popper = o, t
                },
                offset: 0
            },
            preventOverflow: {
                order: 300,
                enabled: !0,
                fn: function (t, i) {
                    var e = i.boundariesElement || Lt(t.instance.popper);
                    t.instance.reference === e && (e = Lt(e));
                    var n = ne("transform"),
                        r = t.instance.popper.style,
                        o = r.top,
                        s = r.left,
                        a = r[n];
                    r.top = "", r.left = "", r[n] = "";
                    var l = Gt(t.instance.popper, t.instance.reference, i.padding, e, t.positionFixed);
                    r.top = o, r.left = s, r[n] = a, i.boundaries = l;
                    var c = i.priority,
                        f = t.offsets.popper,
                        h = {
                            primary: function (t) {
                                var e = f[t];
                                return f[t] < l[t] && !i.escapeWithReference && (e = Math.max(f[t], l[t])), Ut({}, t, e)
                            },
                            secondary: function (t) {
                                var e = "right" === t ? "left" : "top",
                                    n = f[e];
                                return f[t] > l[t] && !i.escapeWithReference && (n = Math.min(f[e], l[t] - ("right" === t ? f.width : f.height))), Ut({}, e, n)
                            }
                        };
                    return c.forEach(function (t) {
                        var e = -1 !== ["left", "top"].indexOf(t) ? "primary" : "secondary";
                        f = Bt({}, f, h[e](t))
                    }), t.offsets.popper = f, t
                },
                priority: ["left", "right", "top", "bottom"],
                padding: 5,
                boundariesElement: "scrollParent"
            },
            keepTogether: {
                order: 400,
                enabled: !0,
                fn: function (t) {
                    var e = t.offsets,
                        n = e.popper,
                        i = e.reference,
                        r = t.placement.split("-")[0],
                        o = Math.floor,
                        s = -1 !== ["top", "bottom"].indexOf(r),
                        a = s ? "right" : "bottom",
                        l = s ? "left" : "top",
                        c = s ? "width" : "height";
                    return n[a] < o(i[l]) && (t.offsets.popper[l] = o(i[l]) - n[c]), n[l] > o(i[a]) && (t.offsets.popper[l] = o(i[a])), t
                }
            },
            arrow: {
                order: 500,
                enabled: !0,
                fn: function (t, e) {
                    var n;
                    if (!le(t.instance.modifiers, "arrow", "keepTogether")) return t;
                    var i = e.element;
                    if ("string" == typeof i) {
                        if (!(i = t.instance.popper.querySelector(i))) return t
                    } else if (!t.instance.popper.contains(i)) return console.warn("WARNING: `arrow.element` must be child of its popper element!"), t;
                    var r = t.placement.split("-")[0],
                        o = t.offsets,
                        s = o.popper,
                        a = o.reference,
                        l = -1 !== ["left", "right"].indexOf(r),
                        c = l ? "height" : "width",
                        f = l ? "Top" : "Left",
                        h = f.toLowerCase(),
                        u = l ? "left" : "top",
                        d = l ? "bottom" : "right",
                        p = Xt(i)[c];
                    a[d] - p < s[h] && (t.offsets.popper[h] -= s[h] - (a[d] - p)), a[h] + p > s[d] && (t.offsets.popper[h] += a[h] + p - s[d]), t.offsets.popper = Kt(t.offsets.popper);
                    var g = a[h] + a[c] / 2 - p / 2,
                        m = Dt(t.instance.popper),
                        _ = parseFloat(m["margin" + f], 10),
                        v = parseFloat(m["border" + f + "Width"], 10),
                        E = g - t.offsets.popper[h] - _ - v;
                    return E = Math.max(Math.min(s[c] - p, E), 0), t.arrowElement = i, t.offsets.arrow = (Ut(n = {}, h, Math.round(E)), Ut(n, u, ""), n), t
                },
                element: "[x-arrow]"
            },
            flip: {
                order: 600,
                enabled: !0,
                fn: function (p, g) {
                    if (ee(p.instance.modifiers, "inner")) return p;
                    if (p.flipped && p.placement === p.originalPlacement) return p;
                    var m = Gt(p.instance.popper, p.instance.reference, g.padding, g.boundariesElement, p.positionFixed),
                        _ = p.placement.split("-")[0],
                        v = Jt(_),
                        E = p.placement.split("-")[1] || "",
                        y = [];
                    switch (g.behavior) {
                        case ue.FLIP:
                            y = [_, v];
                            break;
                        case ue.CLOCKWISE:
                            y = he(_);
                            break;
                        case ue.COUNTERCLOCKWISE:
                            y = he(_, !0);
                            break;
                        default:
                            y = g.behavior
                    }
                    return y.forEach(function (t, e) {
                        if (_ !== t || y.length === e + 1) return p;
                        _ = p.placement.split("-")[0], v = Jt(_);
                        var n, i = p.offsets.popper,
                            r = p.offsets.reference,
                            o = Math.floor,
                            s = "left" === _ && o(i.right) > o(r.left) || "right" === _ && o(i.left) < o(r.right) || "top" === _ && o(i.bottom) > o(r.top) || "bottom" === _ && o(i.top) < o(r.bottom),
                            a = o(i.left) < o(m.left),
                            l = o(i.right) > o(m.right),
                            c = o(i.top) < o(m.top),
                            f = o(i.bottom) > o(m.bottom),
                            h = "left" === _ && a || "right" === _ && l || "top" === _ && c || "bottom" === _ && f,
                            u = -1 !== ["top", "bottom"].indexOf(_),
                            d = !!g.flipVariations && (u && "start" === E && a || u && "end" === E && l || !u && "start" === E && c || !u && "end" === E && f);
                        (s || h || d) && (p.flipped = !0, (s || h) && (_ = y[e + 1]), d && (E = "end" === (n = E) ? "start" : "start" === n ? "end" : n), p.placement = _ + (E ? "-" + E : ""), p.offsets.popper = Bt({}, p.offsets.popper, Zt(p.instance.popper, p.offsets.reference, p.placement)), p = te(p.instance.modifiers, p, "flip"))
                    }), p
                },
                behavior: "flip",
                padding: 5,
                boundariesElement: "viewport"
            },
            inner: {
                order: 700,
                enabled: !1,
                fn: function (t) {
                    var e = t.placement,
                        n = e.split("-")[0],
                        i = t.offsets,
                        r = i.popper,
                        o = i.reference,
                        s = -1 !== ["left", "right"].indexOf(n),
                        a = -1 === ["top", "left"].indexOf(n);
                    return r[s ? "left" : "top"] = o[n] - (a ? r[s ? "width" : "height"] : 0), t.placement = Jt(e), t.offsets.popper = Kt(r), t
                }
            },
            hide: {
                order: 800,
                enabled: !0,
                fn: function (t) {
                    if (!le(t.instance.modifiers, "hide", "preventOverflow")) return t;
                    var e = t.offsets.reference,
                        n = $t(t.instance.modifiers, function (t) {
                            return "preventOverflow" === t.name
                        }).boundaries;
                    if (e.bottom < n.top || e.left > n.right || e.top > n.bottom || e.right < n.left) {
                        if (!0 === t.hide) return t;
                        t.hide = !0, t.attributes["x-out-of-boundaries"] = ""
                    } else {
                        if (!1 === t.hide) return t;
                        t.hide = !1, t.attributes["x-out-of-boundaries"] = !1
                    }
                    return t
                }
            },
            computeStyle: {
                order: 850,
                enabled: !0,
                fn: function (t, e) {
                    var n = e.x,
                        i = e.y,
                        r = t.offsets.popper,
                        o = $t(t.instance.modifiers, function (t) {
                            return "applyStyle" === t.name
                        }).gpuAcceleration;
                    void 0 !== o && console.warn("WARNING: `gpuAcceleration` option moved to `computeStyle` modifier and will not be supported in future versions of Popper.js!");
                    var s = void 0 !== o ? o : e.gpuAcceleration,
                        a = Vt(Lt(t.instance.popper)),
                        l = {
                            position: r.position
                        },
                        c = {
                            left: Math.floor(r.left),
                            top: Math.round(r.top),
                            bottom: Math.round(r.bottom),
                            right: Math.floor(r.right)
                        },
                        f = "bottom" === n ? "top" : "bottom",
                        h = "right" === i ? "left" : "right",
                        u = ne("transform"),
                        d = void 0,
                        p = void 0;
                    if (p = "bottom" === f ? -a.height + c.bottom : c.top, d = "right" === h ? -a.width + c.right : c.left, s && u) l[u] = "translate3d(" + d + "px, " + p + "px, 0)", l[f] = 0, l[h] = 0, l.willChange = "transform";
                    else {
                        var g = "bottom" === f ? -1 : 1,
                            m = "right" === h ? -1 : 1;
                        l[f] = p * g, l[h] = d * m, l.willChange = f + ", " + h
                    }
                    var _ = {
                        "x-placement": t.placement
                    };
                    return t.attributes = Bt({}, _, t.attributes), t.styles = Bt({}, l, t.styles), t.arrowStyles = Bt({}, t.offsets.arrow, t.arrowStyles), t
                },
                gpuAcceleration: !0,
                x: "bottom",
                y: "right"
            },
            applyStyle: {
                order: 900,
                enabled: !0,
                fn: function (t) {
                    var e, n;
                    return ae(t.instance.popper, t.styles), e = t.instance.popper, n = t.attributes, Object.keys(n).forEach(function (t) {
                        !1 !== n[t] ? e.setAttribute(t, n[t]) : e.removeAttribute(t)
                    }), t.arrowElement && Object.keys(t.arrowStyles).length && ae(t.arrowElement, t.arrowStyles), t
                },
                onLoad: function (t, e, n, i, r) {
                    var o = zt(r, e, t, n.positionFixed),
                        s = qt(n.placement, o, e, t, n.modifiers.flip.boundariesElement, n.modifiers.flip.padding);
                    return e.setAttribute("x-placement", s), ae(e, {
                        position: n.positionFixed ? "fixed" : "absolute"
                    }), n
                },
                gpuAcceleration: void 0
            }
        }
    },
        ge = function () {
            function o(t, e) {
                var n = this,
                    i = 2 < arguments.length && void 0 !== arguments[2] ? arguments[2] : {};
                Wt(this, o), this.scheduleUpdate = function () {
                    return requestAnimationFrame(n.update)
                }, this.update = wt(this.update.bind(this)), this.options = Bt({}, o.Defaults, i), this.state = {
                    isDestroyed: !1,
                    isCreated: !1,
                    scrollParents: []
                }, this.reference = t && t.jquery ? t[0] : t, this.popper = e && e.jquery ? e[0] : e, this.options.modifiers = {}, Object.keys(Bt({}, o.Defaults.modifiers, i.modifiers)).forEach(function (t) {
                    n.options.modifiers[t] = Bt({}, o.Defaults.modifiers[t] || {}, i.modifiers ? i.modifiers[t] : {})
                }), this.modifiers = Object.keys(this.options.modifiers).map(function (t) {
                    return Bt({
                        name: t
                    }, n.options.modifiers[t])
                }).sort(function (t, e) {
                    return t.order - e.order
                }), this.modifiers.forEach(function (t) {
                    t.enabled && It(t.onLoad) && t.onLoad(n.reference, n.popper, n.options, t, n.state)
                }), this.update();
                var r = this.options.eventsEnabled;
                r && this.enableEventListeners(), this.state.eventsEnabled = r
            }
            return Ft(o, [{
                key: "update",
                value: function () {
                    return function () {
                        if (!this.state.isDestroyed) {
                            var t = {
                                instance: this,
                                styles: {},
                                arrowStyles: {},
                                attributes: {},
                                flipped: !1,
                                offsets: {}
                            };
                            t.offsets.reference = zt(this.state, this.popper, this.reference, this.options.positionFixed), t.placement = qt(this.options.placement, t.offsets.reference, this.popper, this.reference, this.options.modifiers.flip.boundariesElement, this.options.modifiers.flip.padding), t.originalPlacement = t.placement, t.positionFixed = this.options.positionFixed, t.offsets.popper = Zt(this.popper, t.offsets.reference, t.placement), t.offsets.popper.position = this.options.positionFixed ? "fixed" : "absolute", t = te(this.modifiers, t), this.state.isCreated ? this.options.onUpdate(t) : (this.state.isCreated = !0, this.options.onCreate(t))
                        }
                    }.call(this)
                }
            }, {
                key: "destroy",
                value: function () {
                    return function () {
                        return this.state.isDestroyed = !0, ee(this.modifiers, "applyStyle") && (this.popper.removeAttribute("x-placement"), this.popper.style.position = "", this.popper.style.top = "", this.popper.style.left = "", this.popper.style.right = "", this.popper.style.bottom = "", this.popper.style.willChange = "", this.popper.style[ne("transform")] = ""), this.disableEventListeners(), this.options.removeOnDestroy && this.popper.parentNode.removeChild(this.popper), this
                    }.call(this)
                }
            }, {
                key: "enableEventListeners",
                value: function () {
                    return function () {
                        this.state.eventsEnabled || (this.state = re(this.reference, this.options, this.state, this.scheduleUpdate))
                    }.call(this)
                }
            }, {
                key: "disableEventListeners",
                value: function () {
                    return oe.call(this)
                }
            }]), o
        }();
    ge.Utils = ("undefined" != typeof window ? window : global).PopperUtils, ge.placements = ce, ge.Defaults = pe;
    var me, _e, ve, Ee, ye, be, Te, Ce, we, Ie, De, Ae, Se, Oe, Ne, ke, Le, Pe, xe, je, Me, Re, He, We, Fe, Ue, Be, Ke, Ve, Qe, Ye, Ge, qe, ze, Xe, Je, Ze, $e, tn, en, nn, rn, on, sn, an, ln, cn, fn, hn, un, dn, pn, gn, mn, _n, vn, En, yn, bn, Tn, Cn, wn, In, Dn, An, Sn, On, Nn, kn, Ln, Pn, xn, jn, Mn, Rn, Hn, Wn, Fn, Un, Bn, Kn, Vn, Qn, Yn, Gn, qn, zn, Xn, Jn, Zn, $n, ti, ei, ni, ii, ri, oi, si, ai, li, ci, fi, hi, ui, di, pi, gi, mi, _i, vi, Ei, yi, bi, Ti = (_e = "dropdown", Ee = "." + (ve = "bs.dropdown"), ye = ".data-api", be = (me = e).fn[_e], Te = new RegExp("38|40|27"), Ce = {
        HIDE: "hide" + Ee,
        HIDDEN: "hidden" + Ee,
        SHOW: "show" + Ee,
        SHOWN: "shown" + Ee,
        CLICK: "click" + Ee,
        CLICK_DATA_API: "click" + Ee + ye,
        KEYDOWN_DATA_API: "keydown" + Ee + ye,
        KEYUP_DATA_API: "keyup" + Ee + ye
    }, we = "disabled", Ie = "show", De = "dropup", Ae = "dropright", Se = "dropleft", Oe = "dropdown-menu-right", Ne = "position-static", ke = '[data-toggle="dropdown"]', Le = ".dropdown form", Pe = ".dropdown-menu", xe = ".navbar-nav", je = ".dropdown-menu .dropdown-item:not(.disabled):not(:disabled)", Me = "top-start", Re = "top-end", He = "bottom-start", We = "bottom-end", Fe = "right-start", Ue = "left-start", Be = {
        offset: 0,
        flip: !0,
        boundary: "scrollParent",
        reference: "toggle",
        display: "dynamic"
    }, Ke = {
        offset: "(number|string|function)",
        flip: "boolean",
        boundary: "(string|element)",
        reference: "(string|element)",
        display: "string"
    }, Ve = function () {
        function l(t, e) {
            this._element = t, this._popper = null, this._config = this._getConfig(e), this._menu = this._getMenuElement(), this._inNavbar = this._detectNavbar(), this._addEventListeners()
        }
        var t = l.prototype;
        return t.toggle = function () {
            if (!this._element.disabled && !me(this._element).hasClass(we)) {
                var t = l._getParentFromElement(this._element),
                    e = me(this._menu).hasClass(Ie);
                if (l._clearMenus(), !e) {
                    var n = {
                        relatedTarget: this._element
                    },
                        i = me.Event(Ce.SHOW, n);
                    if (me(t).trigger(i), !i.isDefaultPrevented()) {
                        if (!this._inNavbar) {
                            if ("undefined" == typeof ge) throw new TypeError("Bootstrap dropdown require Popper.js (https://popper.js.org)");
                            var r = this._element;
                            "parent" === this._config.reference ? r = t : gt.isElement(this._config.reference) && (r = this._config.reference, "undefined" != typeof this._config.reference.jquery && (r = this._config.reference[0])), "scrollParent" !== this._config.boundary && me(t).addClass(Ne), this._popper = new ge(r, this._menu, this._getPopperConfig())
                        }
                        "ontouchstart" in document.documentElement && 0 === me(t).closest(xe).length && me(document.body).children().on("mouseover", null, me.noop), this._element.focus(), this._element.setAttribute("aria-expanded", !0), me(this._menu).toggleClass(Ie), me(t).toggleClass(Ie).trigger(me.Event(Ce.SHOWN, n))
                    }
                }
            }
        }, t.dispose = function () {
            me.removeData(this._element, ve), me(this._element).off(Ee), this._element = null, (this._menu = null) !== this._popper && (this._popper.destroy(), this._popper = null)
        }, t.update = function () {
            this._inNavbar = this._detectNavbar(), null !== this._popper && this._popper.scheduleUpdate()
        }, t._addEventListeners = function () {
            var e = this;
            me(this._element).on(Ce.CLICK, function (t) {
                t.preventDefault(), t.stopPropagation(), e.toggle()
            })
        }, t._getConfig = function (t) {
            return t = c({}, this.constructor.Default, me(this._element).data(), t), gt.typeCheckConfig(_e, t, this.constructor.DefaultType), t
        }, t._getMenuElement = function () {
            if (!this._menu) {
                var t = l._getParentFromElement(this._element);
                this._menu = me(t).find(Pe)[0]
            }
            return this._menu
        }, t._getPlacement = function () {
            var t = me(this._element).parent(),
                e = He;
            return t.hasClass(De) ? (e = Me, me(this._menu).hasClass(Oe) && (e = Re)) : t.hasClass(Ae) ? e = Fe : t.hasClass(Se) ? e = Ue : me(this._menu).hasClass(Oe) && (e = We), e
        }, t._detectNavbar = function () {
            return 0 < me(this._element).closest(".navbar").length
        }, t._getPopperConfig = function () {
            var e = this,
                t = {};
            "function" == typeof this._config.offset ? t.fn = function (t) {
                return t.offsets = c({}, t.offsets, e._config.offset(t.offsets) || {}), t
            } : t.offset = this._config.offset;
            var n = {
                placement: this._getPlacement(),
                modifiers: {
                    offset: t,
                    flip: {
                        enabled: this._config.flip
                    },
                    preventOverflow: {
                        boundariesElement: this._config.boundary
                    }
                }
            };
            return "static" === this._config.display && (n.modifiers.applyStyle = {
                enabled: !1
            }), n
        }, l._jQueryInterface = function (e) {
            return this.each(function () {
                var t = me(this).data(ve);
                if (t || (t = new l(this, "object" == typeof e ? e : null), me(this).data(ve, t)), "string" == typeof e) {
                    if ("undefined" == typeof t[e]) throw new TypeError('No method named "' + e + '"');
                    t[e]()
                }
            })
        }, l._clearMenus = function (t) {
            if (!t || 3 !== t.which && ("keyup" !== t.type || 9 === t.which))
                for (var e = me.makeArray(me(ke)), n = 0; n < e.length; n++) {
                    var i = l._getParentFromElement(e[n]),
                        r = me(e[n]).data(ve),
                        o = {
                            relatedTarget: e[n]
                        };
                    if (r) {
                        var s = r._menu;
                        if (me(i).hasClass(Ie) && !(t && ("click" === t.type && /input|textarea/i.test(t.target.tagName) || "keyup" === t.type && 9 === t.which) && me.contains(i, t.target))) {
                            var a = me.Event(Ce.HIDE, o);
                            me(i).trigger(a), a.isDefaultPrevented() || ("ontouchstart" in document.documentElement && me(document.body).children().off("mouseover", null, me.noop), e[n].setAttribute("aria-expanded", "false"), me(s).removeClass(Ie), me(i).removeClass(Ie).trigger(me.Event(Ce.HIDDEN, o)))
                        }
                    }
                }
        }, l._getParentFromElement = function (t) {
            var e, n = gt.getSelectorFromElement(t);
            return n && (e = me(n)[0]), e || t.parentNode
        }, l._dataApiKeydownHandler = function (t) {
            if ((/input|textarea/i.test(t.target.tagName) ? !(32 === t.which || 27 !== t.which && (40 !== t.which && 38 !== t.which || me(t.target).closest(Pe).length)) : Te.test(t.which)) && (t.preventDefault(), t.stopPropagation(), !this.disabled && !me(this).hasClass(we))) {
                var e = l._getParentFromElement(this),
                    n = me(e).hasClass(Ie);
                if ((n || 27 === t.which && 32 === t.which) && (!n || 27 !== t.which && 32 !== t.which)) {
                    var i = me(e).find(je).get();
                    if (0 !== i.length) {
                        var r = i.indexOf(t.target);
                        38 === t.which && 0 < r && r-- , 40 === t.which && r < i.length - 1 && r++ , r < 0 && (r = 0), i[r].focus()
                    }
                } else {
                    if (27 === t.which) {
                        var o = me(e).find(ke)[0];
                        me(o).trigger("focus")
                    }
                    me(this).trigger("click")
                }
            }
        }, s(l, null, [{
            key: "VERSION",
            get: function () {
                return "4.1.1"
            }
        }, {
            key: "Default",
            get: function () {
                return Be
            }
        }, {
            key: "DefaultType",
            get: function () {
                return Ke
            }
        }]), l
    }(), me(document).on(Ce.KEYDOWN_DATA_API, ke, Ve._dataApiKeydownHandler).on(Ce.KEYDOWN_DATA_API, Pe, Ve._dataApiKeydownHandler).on(Ce.CLICK_DATA_API + " " + Ce.KEYUP_DATA_API, Ve._clearMenus).on(Ce.CLICK_DATA_API, ke, function (t) {
        t.preventDefault(), t.stopPropagation(), Ve._jQueryInterface.call(me(this), "toggle")
    }).on(Ce.CLICK_DATA_API, Le, function (t) {
        t.stopPropagation()
    }), me.fn[_e] = Ve._jQueryInterface, me.fn[_e].Constructor = Ve, me.fn[_e].noConflict = function () {
        return me.fn[_e] = be, Ve._jQueryInterface
    }, Ve),
        Ci = (Ye = "modal", qe = "." + (Ge = "bs.modal"), ze = (Qe = e).fn[Ye], Xe = {
            backdrop: !0,
            keyboard: !0,
            focus: !0,
            show: !0
        }, Je = {
            backdrop: "(boolean|string)",
            keyboard: "boolean",
            focus: "boolean",
            show: "boolean"
        }, Ze = {
            HIDE: "hide" + qe,
            HIDDEN: "hidden" + qe,
            SHOW: "show" + qe,
            SHOWN: "shown" + qe,
            FOCUSIN: "focusin" + qe,
            RESIZE: "resize" + qe,
            CLICK_DISMISS: "click.dismiss" + qe,
            KEYDOWN_DISMISS: "keydown.dismiss" + qe,
            MOUSEUP_DISMISS: "mouseup.dismiss" + qe,
            MOUSEDOWN_DISMISS: "mousedown.dismiss" + qe,
            CLICK_DATA_API: "click" + qe + ".data-api"
        }, $e = "modal-scrollbar-measure", tn = "modal-backdrop", en = "modal-open", nn = "fade", rn = "show", on = {
            DIALOG: ".modal-dialog",
            DATA_TOGGLE: '[data-toggle="modal"]',
            DATA_DISMISS: '[data-dismiss="modal"]',
            FIXED_CONTENT: ".fixed-top, .fixed-bottom, .is-fixed, .sticky-top",
            STICKY_CONTENT: ".sticky-top",
            NAVBAR_TOGGLER: ".navbar-toggler"
        }, sn = function () {
            function r(t, e) {
                this._config = this._getConfig(e), this._element = t, this._dialog = Qe(t).find(on.DIALOG)[0], this._backdrop = null, this._isShown = !1, this._isBodyOverflowing = !1, this._ignoreBackdropClick = !1, this._scrollbarWidth = 0
            }
            var t = r.prototype;
            return t.toggle = function (t) {
                return this._isShown ? this.hide() : this.show(t)
            }, t.show = function (t) {
                var e = this;
                if (!this._isTransitioning && !this._isShown) {
                    Qe(this._element).hasClass(nn) && (this._isTransitioning = !0);
                    var n = Qe.Event(Ze.SHOW, {
                        relatedTarget: t
                    });
                    Qe(this._element).trigger(n), this._isShown || n.isDefaultPrevented() || (this._isShown = !0, this._checkScrollbar(), this._setScrollbar(), this._adjustDialog(), Qe(document.body).addClass(en), this._setEscapeEvent(), this._setResizeEvent(), Qe(this._element).on(Ze.CLICK_DISMISS, on.DATA_DISMISS, function (t) {
                        return e.hide(t)
                    }), Qe(this._dialog).on(Ze.MOUSEDOWN_DISMISS, function () {
                        Qe(e._element).one(Ze.MOUSEUP_DISMISS, function (t) {
                            Qe(t.target).is(e._element) && (e._ignoreBackdropClick = !0)
                        })
                    }), this._showBackdrop(function () {
                        return e._showElement(t)
                    }))
                }
            }, t.hide = function (t) {
                var e = this;
                if (t && t.preventDefault(), !this._isTransitioning && this._isShown) {
                    var n = Qe.Event(Ze.HIDE);
                    if (Qe(this._element).trigger(n), this._isShown && !n.isDefaultPrevented()) {
                        this._isShown = !1;
                        var i = Qe(this._element).hasClass(nn);
                        if (i && (this._isTransitioning = !0), this._setEscapeEvent(), this._setResizeEvent(), Qe(document).off(Ze.FOCUSIN), Qe(this._element).removeClass(rn), Qe(this._element).off(Ze.CLICK_DISMISS), Qe(this._dialog).off(Ze.MOUSEDOWN_DISMISS), i) {
                            var r = gt.getTransitionDurationFromElement(this._element);
                            Qe(this._element).one(gt.TRANSITION_END, function (t) {
                                return e._hideModal(t)
                            }).emulateTransitionEnd(r)
                        } else this._hideModal()
                    }
                }
            }, t.dispose = function () {
                Qe.removeData(this._element, Ge), Qe(window, document, this._element, this._backdrop).off(qe), this._config = null, this._element = null, this._dialog = null, this._backdrop = null, this._isShown = null, this._isBodyOverflowing = null, this._ignoreBackdropClick = null, this._scrollbarWidth = null
            }, t.handleUpdate = function () {
                this._adjustDialog()
            }, t._getConfig = function (t) {
                return t = c({}, Xe, t), gt.typeCheckConfig(Ye, t, Je), t
            }, t._showElement = function (t) {
                var e = this,
                    n = Qe(this._element).hasClass(nn);
                this._element.parentNode && this._element.parentNode.nodeType === Node.ELEMENT_NODE || document.body.appendChild(this._element), this._element.style.display = "block", this._element.removeAttribute("aria-hidden"), this._element.scrollTop = 0, n && gt.reflow(this._element), Qe(this._element).addClass(rn), this._config.focus && this._enforceFocus();
                var i = Qe.Event(Ze.SHOWN, {
                    relatedTarget: t
                }),
                    r = function () {
                        e._config.focus && e._element.focus(), e._isTransitioning = !1, Qe(e._element).trigger(i)
                    };
                if (n) {
                    var o = gt.getTransitionDurationFromElement(this._element);
                    Qe(this._dialog).one(gt.TRANSITION_END, r).emulateTransitionEnd(o)
                } else r()
            }, t._enforceFocus = function () {
                var e = this;
                Qe(document).off(Ze.FOCUSIN).on(Ze.FOCUSIN, function (t) {
                    document !== t.target && e._element !== t.target && 0 === Qe(e._element).has(t.target).length && e._element.focus()
                })
            }, t._setEscapeEvent = function () {
                var e = this;
                this._isShown && this._config.keyboard ? Qe(this._element).on(Ze.KEYDOWN_DISMISS, function (t) {
                    27 === t.which && (t.preventDefault(), e.hide())
                }) : this._isShown || Qe(this._element).off(Ze.KEYDOWN_DISMISS)
            }, t._setResizeEvent = function () {
                var e = this;
                this._isShown ? Qe(window).on(Ze.RESIZE, function (t) {
                    return e.handleUpdate(t)
                }) : Qe(window).off(Ze.RESIZE)
            }, t._hideModal = function () {
                var t = this;
                this._element.style.display = "none", this._element.setAttribute("aria-hidden", !0), this._isTransitioning = !1, this._showBackdrop(function () {
                    Qe(document.body).removeClass(en), t._resetAdjustments(), t._resetScrollbar(), Qe(t._element).trigger(Ze.HIDDEN)
                })
            }, t._removeBackdrop = function () {
                this._backdrop && (Qe(this._backdrop).remove(), this._backdrop = null)
            }, t._showBackdrop = function (t) {
                var e = this,
                    n = Qe(this._element).hasClass(nn) ? nn : "";
                if (this._isShown && this._config.backdrop) {
                    if (this._backdrop = document.createElement("div"), this._backdrop.className = tn, n && Qe(this._backdrop).addClass(n), Qe(this._backdrop).appendTo(document.body), Qe(this._element).on(Ze.CLICK_DISMISS, function (t) {
                        e._ignoreBackdropClick ? e._ignoreBackdropClick = !1 : t.target === t.currentTarget && ("static" === e._config.backdrop ? e._element.focus() : e.hide())
                    }), n && gt.reflow(this._backdrop), Qe(this._backdrop).addClass(rn), !t) return;
                    if (!n) return void t();
                    var i = gt.getTransitionDurationFromElement(this._backdrop);
                    Qe(this._backdrop).one(gt.TRANSITION_END, t).emulateTransitionEnd(i)
                } else if (!this._isShown && this._backdrop) {
                    Qe(this._backdrop).removeClass(rn);
                    var r = function () {
                        e._removeBackdrop(), t && t()
                    };
                    if (Qe(this._element).hasClass(nn)) {
                        var o = gt.getTransitionDurationFromElement(this._backdrop);
                        Qe(this._backdrop).one(gt.TRANSITION_END, r).emulateTransitionEnd(o)
                    } else r()
                } else t && t()
            }, t._adjustDialog = function () {
                var t = this._element.scrollHeight > document.documentElement.clientHeight;
                !this._isBodyOverflowing && t && (this._element.style.paddingLeft = this._scrollbarWidth + "px"), this._isBodyOverflowing && !t && (this._element.style.paddingRight = this._scrollbarWidth + "px")
            }, t._resetAdjustments = function () {
                this._element.style.paddingLeft = "", this._element.style.paddingRight = ""
            }, t._checkScrollbar = function () {
                var t = document.body.getBoundingClientRect();
                this._isBodyOverflowing = t.left + t.right < window.innerWidth, this._scrollbarWidth = this._getScrollbarWidth()
            }, t._setScrollbar = function () {
                var r = this;
                if (this._isBodyOverflowing) {
                    Qe(on.FIXED_CONTENT).each(function (t, e) {
                        var n = Qe(e)[0].style.paddingRight,
                            i = Qe(e).css("padding-right");
                        Qe(e).data("padding-right", n).css("padding-right", parseFloat(i) + r._scrollbarWidth + "px")
                    }), Qe(on.STICKY_CONTENT).each(function (t, e) {
                        var n = Qe(e)[0].style.marginRight,
                            i = Qe(e).css("margin-right");
                        Qe(e).data("margin-right", n).css("margin-right", parseFloat(i) - r._scrollbarWidth + "px")
                    }), Qe(on.NAVBAR_TOGGLER).each(function (t, e) {
                        var n = Qe(e)[0].style.marginRight,
                            i = Qe(e).css("margin-right");
                        Qe(e).data("margin-right", n).css("margin-right", parseFloat(i) + r._scrollbarWidth + "px")
                    });
                    var t = document.body.style.paddingRight,
                        e = Qe(document.body).css("padding-right");
                    Qe(document.body).data("padding-right", t).css("padding-right", parseFloat(e) + this._scrollbarWidth + "px")
                }
            }, t._resetScrollbar = function () {
                Qe(on.FIXED_CONTENT).each(function (t, e) {
                    var n = Qe(e).data("padding-right");
                    "undefined" != typeof n && Qe(e).css("padding-right", n).removeData("padding-right")
                }), Qe(on.STICKY_CONTENT + ", " + on.NAVBAR_TOGGLER).each(function (t, e) {
                    var n = Qe(e).data("margin-right");
                    "undefined" != typeof n && Qe(e).css("margin-right", n).removeData("margin-right")
                });
                var t = Qe(document.body).data("padding-right");
                "undefined" != typeof t && Qe(document.body).css("padding-right", t).removeData("padding-right")
            }, t._getScrollbarWidth = function () {
                var t = document.createElement("div");
                t.className = $e, document.body.appendChild(t);
                var e = t.getBoundingClientRect().width - t.clientWidth;
                return document.body.removeChild(t), e
            }, r._jQueryInterface = function (n, i) {
                return this.each(function () {
                    var t = Qe(this).data(Ge),
                        e = c({}, Xe, Qe(this).data(), "object" == typeof n && n ? n : {});
                    if (t || (t = new r(this, e), Qe(this).data(Ge, t)), "string" == typeof n) {
                        if ("undefined" == typeof t[n]) throw new TypeError('No method named "' + n + '"');
                        t[n](i)
                    } else e.show && t.show(i)
                })
            }, s(r, null, [{
                key: "VERSION",
                get: function () {
                    return "4.1.1"
                }
            }, {
                key: "Default",
                get: function () {
                    return Xe
                }
            }]), r
        }(), Qe(document).on(Ze.CLICK_DATA_API, on.DATA_TOGGLE, function (t) {
            var e, n = this,
                i = gt.getSelectorFromElement(this);
            i && (e = Qe(i)[0]);
            var r = Qe(e).data(Ge) ? "toggle" : c({}, Qe(e).data(), Qe(this).data());
            "A" !== this.tagName && "AREA" !== this.tagName || t.preventDefault();
            var o = Qe(e).one(Ze.SHOW, function (t) {
                t.isDefaultPrevented() || o.one(Ze.HIDDEN, function () {
                    Qe(n).is(":visible") && n.focus()
                })
            });
            sn._jQueryInterface.call(Qe(e), r, this)
        }), Qe.fn[Ye] = sn._jQueryInterface, Qe.fn[Ye].Constructor = sn, Qe.fn[Ye].noConflict = function () {
            return Qe.fn[Ye] = ze, sn._jQueryInterface
        }, sn),
        wi = (ln = "tooltip", fn = "." + (cn = "bs.tooltip"), hn = (an = e).fn[ln], un = "bs-tooltip", dn = new RegExp("(^|\\s)" + un + "\\S+", "g"), mn = {
            animation: !0,
            template: '<div class="tooltip" role="tooltip"><div class="arrow"></div><div class="tooltip-inner"></div></div>',
            trigger: "hover focus",
            title: "",
            delay: 0,
            html: !(gn = {
                AUTO: "auto",
                TOP: "top",
                RIGHT: "right",
                BOTTOM: "bottom",
                LEFT: "left"
            }),
            selector: !(pn = {
                animation: "boolean",
                template: "string",
                title: "(string|element|function)",
                trigger: "string",
                delay: "(number|object)",
                html: "boolean",
                selector: "(string|boolean)",
                placement: "(string|function)",
                offset: "(number|string)",
                container: "(string|element|boolean)",
                fallbackPlacement: "(string|array)",
                boundary: "(string|element)"
            }),
            placement: "top",
            offset: 0,
            container: !1,
            fallbackPlacement: "flip",
            boundary: "scrollParent"
        }, vn = "out", En = {
            HIDE: "hide" + fn,
            HIDDEN: "hidden" + fn,
            SHOW: (_n = "show") + fn,
            SHOWN: "shown" + fn,
            INSERTED: "inserted" + fn,
            CLICK: "click" + fn,
            FOCUSIN: "focusin" + fn,
            FOCUSOUT: "focusout" + fn,
            MOUSEENTER: "mouseenter" + fn,
            MOUSELEAVE: "mouseleave" + fn
        }, yn = "fade", bn = "show", Tn = ".tooltip-inner", Cn = ".arrow", wn = "hover", In = "focus", Dn = "click", An = "manual", Sn = function () {
            function i(t, e) {
                if ("undefined" == typeof ge) throw new TypeError("Bootstrap tooltips require Popper.js (https://popper.js.org)");
                this._isEnabled = !0, this._timeout = 0, this._hoverState = "", this._activeTrigger = {}, this._popper = null, this.element = t, this.config = this._getConfig(e), this.tip = null, this._setListeners()
            }
            var t = i.prototype;
            return t.enable = function () {
                this._isEnabled = !0
            }, t.disable = function () {
                this._isEnabled = !1
            }, t.toggleEnabled = function () {
                this._isEnabled = !this._isEnabled
            }, t.toggle = function (t) {
                if (this._isEnabled)
                    if (t) {
                        var e = this.constructor.DATA_KEY,
                            n = an(t.currentTarget).data(e);
                        n || (n = new this.constructor(t.currentTarget, this._getDelegateConfig()), an(t.currentTarget).data(e, n)), n._activeTrigger.click = !n._activeTrigger.click, n._isWithActiveTrigger() ? n._enter(null, n) : n._leave(null, n)
                    } else {
                        if (an(this.getTipElement()).hasClass(bn)) return void this._leave(null, this);
                        this._enter(null, this)
                    }
            }, t.dispose = function () {
                clearTimeout(this._timeout), an.removeData(this.element, this.constructor.DATA_KEY), an(this.element).off(this.constructor.EVENT_KEY), an(this.element).closest(".modal").off("hide.bs.modal"), this.tip && an(this.tip).remove(), this._isEnabled = null, this._timeout = null, this._hoverState = null, (this._activeTrigger = null) !== this._popper && this._popper.destroy(), this._popper = null, this.element = null, this.config = null, this.tip = null
            }, t.show = function () {
                var e = this;
                if ("none" === an(this.element).css("display")) throw new Error("Please use show on visible elements");
                var t = an.Event(this.constructor.Event.SHOW);
                if (this.isWithContent() && this._isEnabled) {
                    an(this.element).trigger(t);
                    var n = an.contains(this.element.ownerDocument.documentElement, this.element);
                    if (t.isDefaultPrevented() || !n) return;
                    var i = this.getTipElement(),
                        r = gt.getUID(this.constructor.NAME);
                    i.setAttribute("id", r), this.element.setAttribute("aria-describedby", r), this.setContent(), this.config.animation && an(i).addClass(yn);
                    var o = "function" == typeof this.config.placement ? this.config.placement.call(this, i, this.element) : this.config.placement,
                        s = this._getAttachment(o);
                    this.addAttachmentClass(s);
                    var a = !1 === this.config.container ? document.body : an(this.config.container);
                    an(i).data(this.constructor.DATA_KEY, this), an.contains(this.element.ownerDocument.documentElement, this.tip) || an(i).appendTo(a), an(this.element).trigger(this.constructor.Event.INSERTED), this._popper = new ge(this.element, i, {
                        placement: s,
                        modifiers: {
                            offset: {
                                offset: this.config.offset
                            },
                            flip: {
                                behavior: this.config.fallbackPlacement
                            },
                            arrow: {
                                element: Cn
                            },
                            preventOverflow: {
                                boundariesElement: this.config.boundary
                            }
                        },
                        onCreate: function (t) {
                            t.originalPlacement !== t.placement && e._handlePopperPlacementChange(t)
                        },
                        onUpdate: function (t) {
                            e._handlePopperPlacementChange(t)
                        }
                    }), an(i).addClass(bn), "ontouchstart" in document.documentElement && an(document.body).children().on("mouseover", null, an.noop);
                    var l = function () {
                        e.config.animation && e._fixTransition();
                        var t = e._hoverState;
                        e._hoverState = null, an(e.element).trigger(e.constructor.Event.SHOWN), t === vn && e._leave(null, e)
                    };
                    if (an(this.tip).hasClass(yn)) {
                        var c = gt.getTransitionDurationFromElement(this.tip);
                        an(this.tip).one(gt.TRANSITION_END, l).emulateTransitionEnd(c)
                    } else l()
                }
            }, t.hide = function (t) {
                var e = this,
                    n = this.getTipElement(),
                    i = an.Event(this.constructor.Event.HIDE),
                    r = function () {
                        e._hoverState !== _n && n.parentNode && n.parentNode.removeChild(n), e._cleanTipClass(), e.element.removeAttribute("aria-describedby"), an(e.element).trigger(e.constructor.Event.HIDDEN), null !== e._popper && e._popper.destroy(), t && t()
                    };
                if (an(this.element).trigger(i), !i.isDefaultPrevented()) {
                    if (an(n).removeClass(bn), "ontouchstart" in document.documentElement && an(document.body).children().off("mouseover", null, an.noop), this._activeTrigger[Dn] = !1, this._activeTrigger[In] = !1, this._activeTrigger[wn] = !1, an(this.tip).hasClass(yn)) {
                        var o = gt.getTransitionDurationFromElement(n);
                        an(n).one(gt.TRANSITION_END, r).emulateTransitionEnd(o)
                    } else r();
                    this._hoverState = ""
                }
            }, t.update = function () {
                null !== this._popper && this._popper.scheduleUpdate()
            }, t.isWithContent = function () {
                return Boolean(this.getTitle())
            }, t.addAttachmentClass = function (t) {
                an(this.getTipElement()).addClass(un + "-" + t)
            }, t.getTipElement = function () {
                return this.tip = this.tip || an(this.config.template)[0], this.tip
            }, t.setContent = function () {
                var t = an(this.getTipElement());
                this.setElementContent(t.find(Tn), this.getTitle()), t.removeClass(yn + " " + bn)
            }, t.setElementContent = function (t, e) {
                var n = this.config.html;
                "object" == typeof e && (e.nodeType || e.jquery) ? n ? an(e).parent().is(t) || t.empty().append(e) : t.text(an(e).text()) : t[n ? "html" : "text"](e)
            }, t.getTitle = function () {
                var t = this.element.getAttribute("data-original-title");
                return t || (t = "function" == typeof this.config.title ? this.config.title.call(this.element) : this.config.title), t
            }, t._getAttachment = function (t) {
                return gn[t.toUpperCase()]
            }, t._setListeners = function () {
                var i = this;
                this.config.trigger.split(" ").forEach(function (t) {
                    if ("click" === t) an(i.element).on(i.constructor.Event.CLICK, i.config.selector, function (t) {
                        return i.toggle(t)
                    });
                    else if (t !== An) {
                        var e = t === wn ? i.constructor.Event.MOUSEENTER : i.constructor.Event.FOCUSIN,
                            n = t === wn ? i.constructor.Event.MOUSELEAVE : i.constructor.Event.FOCUSOUT;
                        an(i.element).on(e, i.config.selector, function (t) {
                            return i._enter(t)
                        }).on(n, i.config.selector, function (t) {
                            return i._leave(t)
                        })
                    }
                    an(i.element).closest(".modal").on("hide.bs.modal", function () {
                        return i.hide()
                    })
                }), this.config.selector ? this.config = c({}, this.config, {
                    trigger: "manual",
                    selector: ""
                }) : this._fixTitle()
            }, t._fixTitle = function () {
                var t = typeof this.element.getAttribute("data-original-title");
                (this.element.getAttribute("title") || "string" !== t) && (this.element.setAttribute("data-original-title", this.element.getAttribute("title") || ""), this.element.setAttribute("title", ""))
            }, t._enter = function (t, e) {
                var n = this.constructor.DATA_KEY;
                (e = e || an(t.currentTarget).data(n)) || (e = new this.constructor(t.currentTarget, this._getDelegateConfig()), an(t.currentTarget).data(n, e)), t && (e._activeTrigger["focusin" === t.type ? In : wn] = !0), an(e.getTipElement()).hasClass(bn) || e._hoverState === _n ? e._hoverState = _n : (clearTimeout(e._timeout), e._hoverState = _n, e.config.delay && e.config.delay.show ? e._timeout = setTimeout(function () {
                    e._hoverState === _n && e.show()
                }, e.config.delay.show) : e.show())
            }, t._leave = function (t, e) {
                var n = this.constructor.DATA_KEY;
                (e = e || an(t.currentTarget).data(n)) || (e = new this.constructor(t.currentTarget, this._getDelegateConfig()), an(t.currentTarget).data(n, e)), t && (e._activeTrigger["focusout" === t.type ? In : wn] = !1), e._isWithActiveTrigger() || (clearTimeout(e._timeout), e._hoverState = vn, e.config.delay && e.config.delay.hide ? e._timeout = setTimeout(function () {
                    e._hoverState === vn && e.hide()
                }, e.config.delay.hide) : e.hide())
            }, t._isWithActiveTrigger = function () {
                for (var t in this._activeTrigger)
                    if (this._activeTrigger[t]) return !0;
                return !1
            }, t._getConfig = function (t) {
                return "number" == typeof (t = c({}, this.constructor.Default, an(this.element).data(), "object" == typeof t && t ? t : {})).delay && (t.delay = {
                    show: t.delay,
                    hide: t.delay
                }), "number" == typeof t.title && (t.title = t.title.toString()), "number" == typeof t.content && (t.content = t.content.toString()), gt.typeCheckConfig(ln, t, this.constructor.DefaultType), t
            }, t._getDelegateConfig = function () {
                var t = {};
                if (this.config)
                    for (var e in this.config) this.constructor.Default[e] !== this.config[e] && (t[e] = this.config[e]);
                return t
            }, t._cleanTipClass = function () {
                var t = an(this.getTipElement()),
                    e = t.attr("class").match(dn);
                null !== e && 0 < e.length && t.removeClass(e.join(""))
            }, t._handlePopperPlacementChange = function (t) {
                this._cleanTipClass(), this.addAttachmentClass(this._getAttachment(t.placement))
            }, t._fixTransition = function () {
                var t = this.getTipElement(),
                    e = this.config.animation;
                null === t.getAttribute("x-placement") && (an(t).removeClass(yn), this.config.animation = !1, this.hide(), this.show(), this.config.animation = e)
            }, i._jQueryInterface = function (n) {
                return this.each(function () {
                    var t = an(this).data(cn),
                        e = "object" == typeof n && n;
                    if ((t || !/dispose|hide/.test(n)) && (t || (t = new i(this, e), an(this).data(cn, t)), "string" == typeof n)) {
                        if ("undefined" == typeof t[n]) throw new TypeError('No method named "' + n + '"');
                        t[n]()
                    }
                })
            }, s(i, null, [{
                key: "VERSION",
                get: function () {
                    return "4.1.1"
                }
            }, {
                key: "Default",
                get: function () {
                    return mn
                }
            }, {
                key: "NAME",
                get: function () {
                    return ln
                }
            }, {
                key: "DATA_KEY",
                get: function () {
                    return cn
                }
            }, {
                key: "Event",
                get: function () {
                    return En
                }
            }, {
                key: "EVENT_KEY",
                get: function () {
                    return fn
                }
            }, {
                key: "DefaultType",
                get: function () {
                    return pn
                }
            }]), i
        }(), an.fn[ln] = Sn._jQueryInterface, an.fn[ln].Constructor = Sn, an.fn[ln].noConflict = function () {
            return an.fn[ln] = hn, Sn._jQueryInterface
        }, Sn),
        Ii = (Nn = "popover", Ln = "." + (kn = "bs.popover"), Pn = (On = e).fn[Nn], xn = "bs-popover", jn = new RegExp("(^|\\s)" + xn + "\\S+", "g"), Mn = c({}, wi.Default, {
            placement: "right",
            trigger: "click",
            content: "",
            template: '<div class="popover" role="tooltip"><div class="arrow"></div><h3 class="popover-header"></h3><div class="popover-body"></div></div>'
        }), Rn = c({}, wi.DefaultType, {
            content: "(string|element|function)"
        }), Hn = "fade", Fn = ".popover-header", Un = ".popover-body", Bn = {
            HIDE: "hide" + Ln,
            HIDDEN: "hidden" + Ln,
            SHOW: (Wn = "show") + Ln,
            SHOWN: "shown" + Ln,
            INSERTED: "inserted" + Ln,
            CLICK: "click" + Ln,
            FOCUSIN: "focusin" + Ln,
            FOCUSOUT: "focusout" + Ln,
            MOUSEENTER: "mouseenter" + Ln,
            MOUSELEAVE: "mouseleave" + Ln
        }, Kn = function (t) {
            var e, n;

            function i() {
                return t.apply(this, arguments) || this
            }
            n = t, (e = i).prototype = Object.create(n.prototype), (e.prototype.constructor = e).__proto__ = n;
            var r = i.prototype;
            return r.isWithContent = function () {
                return this.getTitle() || this._getContent()
            }, r.addAttachmentClass = function (t) {
                On(this.getTipElement()).addClass(xn + "-" + t)
            }, r.getTipElement = function () {
                return this.tip = this.tip || On(this.config.template)[0], this.tip
            }, r.setContent = function () {
                var t = On(this.getTipElement());
                this.setElementContent(t.find(Fn), this.getTitle());
                var e = this._getContent();
                "function" == typeof e && (e = e.call(this.element)), this.setElementContent(t.find(Un), e), t.removeClass(Hn + " " + Wn)
            }, r._getContent = function () {
                return this.element.getAttribute("data-content") || this.config.content
            }, r._cleanTipClass = function () {
                var t = On(this.getTipElement()),
                    e = t.attr("class").match(jn);
                null !== e && 0 < e.length && t.removeClass(e.join(""))
            }, i._jQueryInterface = function (n) {
                return this.each(function () {
                    var t = On(this).data(kn),
                        e = "object" == typeof n ? n : null;
                    if ((t || !/destroy|hide/.test(n)) && (t || (t = new i(this, e), On(this).data(kn, t)), "string" == typeof n)) {
                        if ("undefined" == typeof t[n]) throw new TypeError('No method named "' + n + '"');
                        t[n]()
                    }
                })
            }, s(i, null, [{
                key: "VERSION",
                get: function () {
                    return "4.1.1"
                }
            }, {
                key: "Default",
                get: function () {
                    return Mn
                }
            }, {
                key: "NAME",
                get: function () {
                    return Nn
                }
            }, {
                key: "DATA_KEY",
                get: function () {
                    return kn
                }
            }, {
                key: "Event",
                get: function () {
                    return Bn
                }
            }, {
                key: "EVENT_KEY",
                get: function () {
                    return Ln
                }
            }, {
                key: "DefaultType",
                get: function () {
                    return Rn
                }
            }]), i
        }(wi), On.fn[Nn] = Kn._jQueryInterface, On.fn[Nn].Constructor = Kn, On.fn[Nn].noConflict = function () {
            return On.fn[Nn] = Pn, Kn._jQueryInterface
        }, Kn),
        Di = (Qn = "scrollspy", Gn = "." + (Yn = "bs.scrollspy"), qn = (Vn = e).fn[Qn], zn = {
            offset: 10,
            method: "auto",
            target: ""
        }, Xn = {
            offset: "number",
            method: "string",
            target: "(string|element)"
        }, Jn = {
            ACTIVATE: "activate" + Gn,
            SCROLL: "scroll" + Gn,
            LOAD_DATA_API: "load" + Gn + ".data-api"
        }, Zn = "dropdown-item", $n = "active", ti = {
            DATA_SPY: '[data-spy="scroll"]',
            ACTIVE: ".active",
            NAV_LIST_GROUP: ".nav, .list-group",
            NAV_LINKS: ".nav-link",
            NAV_ITEMS: ".nav-item",
            LIST_ITEMS: ".list-group-item",
            DROPDOWN: ".dropdown",
            DROPDOWN_ITEMS: ".dropdown-item",
            DROPDOWN_TOGGLE: ".dropdown-toggle"
        }, ei = "offset", ni = "position", ii = function () {
            function n(t, e) {
                var n = this;
                this._element = t, this._scrollElement = "BODY" === t.tagName ? window : t, this._config = this._getConfig(e), this._selector = this._config.target + " " + ti.NAV_LINKS + "," + this._config.target + " " + ti.LIST_ITEMS + "," + this._config.target + " " + ti.DROPDOWN_ITEMS, this._offsets = [], this._targets = [], this._activeTarget = null, this._scrollHeight = 0, Vn(this._scrollElement).on(Jn.SCROLL, function (t) {
                    return n._process(t)
                }), this.refresh(), this._process()
            }
            var t = n.prototype;
            return t.refresh = function () {
                var e = this,
                    t = this._scrollElement === this._scrollElement.window ? ei : ni,
                    r = "auto" === this._config.method ? t : this._config.method,
                    o = r === ni ? this._getScrollTop() : 0;
                this._offsets = [], this._targets = [], this._scrollHeight = this._getScrollHeight(), Vn.makeArray(Vn(this._selector)).map(function (t) {
                    var e, n = gt.getSelectorFromElement(t);
                    if (n && (e = Vn(n)[0]), e) {
                        var i = e.getBoundingClientRect();
                        if (i.width || i.height) return [Vn(e)[r]().top + o, n]
                    }
                    return null
                }).filter(function (t) {
                    return t
                }).sort(function (t, e) {
                    return t[0] - e[0]
                }).forEach(function (t) {
                    e._offsets.push(t[0]), e._targets.push(t[1])
                })
            }, t.dispose = function () {
                Vn.removeData(this._element, Yn), Vn(this._scrollElement).off(Gn), this._element = null, this._scrollElement = null, this._config = null, this._selector = null, this._offsets = null, this._targets = null, this._activeTarget = null, this._scrollHeight = null
            }, t._getConfig = function (t) {
                if ("string" != typeof (t = c({}, zn, "object" == typeof t && t ? t : {})).target) {
                    var e = Vn(t.target).attr("id");
                    e || (e = gt.getUID(Qn), Vn(t.target).attr("id", e)), t.target = "#" + e
                }
                return gt.typeCheckConfig(Qn, t, Xn), t
            }, t._getScrollTop = function () {
                return this._scrollElement === window ? this._scrollElement.pageYOffset : this._scrollElement.scrollTop
            }, t._getScrollHeight = function () {
                return this._scrollElement.scrollHeight || Math.max(document.body.scrollHeight, document.documentElement.scrollHeight)
            }, t._getOffsetHeight = function () {
                return this._scrollElement === window ? window.innerHeight : this._scrollElement.getBoundingClientRect().height
            }, t._process = function () {
                var t = this._getScrollTop() + this._config.offset,
                    e = this._getScrollHeight(),
                    n = this._config.offset + e - this._getOffsetHeight();
                if (this._scrollHeight !== e && this.refresh(), n <= t) {
                    var i = this._targets[this._targets.length - 1];
                    this._activeTarget !== i && this._activate(i)
                } else {
                    if (this._activeTarget && t < this._offsets[0] && 0 < this._offsets[0]) return this._activeTarget = null, void this._clear();
                    for (var r = this._offsets.length; r--;) {
                        this._activeTarget !== this._targets[r] && t >= this._offsets[r] && ("undefined" == typeof this._offsets[r + 1] || t < this._offsets[r + 1]) && this._activate(this._targets[r])
                    }
                }
            }, t._activate = function (e) {
                this._activeTarget = e, this._clear();
                var t = this._selector.split(",");
                t = t.map(function (t) {
                    return t + '[data-target="' + e + '"],' + t + '[href="' + e + '"]'
                });
                var n = Vn(t.join(","));
                n.hasClass(Zn) ? (n.closest(ti.DROPDOWN).find(ti.DROPDOWN_TOGGLE).addClass($n), n.addClass($n)) : (n.addClass($n), n.parents(ti.NAV_LIST_GROUP).prev(ti.NAV_LINKS + ", " + ti.LIST_ITEMS).addClass($n), n.parents(ti.NAV_LIST_GROUP).prev(ti.NAV_ITEMS).children(ti.NAV_LINKS).addClass($n)), Vn(this._scrollElement).trigger(Jn.ACTIVATE, {
                    relatedTarget: e
                })
            }, t._clear = function () {
                Vn(this._selector).filter(ti.ACTIVE).removeClass($n)
            }, n._jQueryInterface = function (e) {
                return this.each(function () {
                    var t = Vn(this).data(Yn);
                    if (t || (t = new n(this, "object" == typeof e && e), Vn(this).data(Yn, t)), "string" == typeof e) {
                        if ("undefined" == typeof t[e]) throw new TypeError('No method named "' + e + '"');
                        t[e]()
                    }
                })
            }, s(n, null, [{
                key: "VERSION",
                get: function () {
                    return "4.1.1"
                }
            }, {
                key: "Default",
                get: function () {
                    return zn
                }
            }]), n
        }(), Vn(window).on(Jn.LOAD_DATA_API, function () {
            for (var t = Vn.makeArray(Vn(ti.DATA_SPY)), e = t.length; e--;) {
                var n = Vn(t[e]);
                ii._jQueryInterface.call(n, n.data())
            }
        }), Vn.fn[Qn] = ii._jQueryInterface, Vn.fn[Qn].Constructor = ii, Vn.fn[Qn].noConflict = function () {
            return Vn.fn[Qn] = qn, ii._jQueryInterface
        }, ii),
        Ai = (si = "." + (oi = "bs.tab"), ai = (ri = e).fn.tab, li = {
            HIDE: "hide" + si,
            HIDDEN: "hidden" + si,
            SHOW: "show" + si,
            SHOWN: "shown" + si,
            CLICK_DATA_API: "click" + si + ".data-api"
        }, ci = "dropdown-menu", fi = "active", hi = "disabled", ui = "fade", di = "show", pi = ".dropdown", gi = ".nav, .list-group", mi = ".active", _i = "> li > .active", vi = '[data-toggle="tab"], [data-toggle="pill"], [data-toggle="list"]', Ei = ".dropdown-toggle", yi = "> .dropdown-menu .active", bi = function () {
            function i(t) {
                this._element = t
            }
            var t = i.prototype;
            return t.show = function () {
                var n = this;
                if (!(this._element.parentNode && this._element.parentNode.nodeType === Node.ELEMENT_NODE && ri(this._element).hasClass(fi) || ri(this._element).hasClass(hi))) {
                    var t, i, e = ri(this._element).closest(gi)[0],
                        r = gt.getSelectorFromElement(this._element);
                    if (e) {
                        var o = "UL" === e.nodeName ? _i : mi;
                        i = (i = ri.makeArray(ri(e).find(o)))[i.length - 1]
                    }
                    var s = ri.Event(li.HIDE, {
                        relatedTarget: this._element
                    }),
                        a = ri.Event(li.SHOW, {
                            relatedTarget: i
                        });
                    if (i && ri(i).trigger(s), ri(this._element).trigger(a), !a.isDefaultPrevented() && !s.isDefaultPrevented()) {
                        r && (t = ri(r)[0]), this._activate(this._element, e);
                        var l = function () {
                            var t = ri.Event(li.HIDDEN, {
                                relatedTarget: n._element
                            }),
                                e = ri.Event(li.SHOWN, {
                                    relatedTarget: i
                                });
                            ri(i).trigger(t), ri(n._element).trigger(e)
                        };
                        t ? this._activate(t, t.parentNode, l) : l()
                    }
                }
            }, t.dispose = function () {
                ri.removeData(this._element, oi), this._element = null
            }, t._activate = function (t, e, n) {
                var i = this,
                    r = ("UL" === e.nodeName ? ri(e).find(_i) : ri(e).children(mi))[0],
                    o = n && r && ri(r).hasClass(ui),
                    s = function () {
                        return i._transitionComplete(t, r, n)
                    };
                if (r && o) {
                    var a = gt.getTransitionDurationFromElement(r);
                    ri(r).one(gt.TRANSITION_END, s).emulateTransitionEnd(a)
                } else s()
            }, t._transitionComplete = function (t, e, n) {
                if (e) {
                    ri(e).removeClass(di + " " + fi);
                    var i = ri(e.parentNode).find(yi)[0];
                    i && ri(i).removeClass(fi), "tab" === e.getAttribute("role") && e.setAttribute("aria-selected", !1)
                }
                if (ri(t).addClass(fi), "tab" === t.getAttribute("role") && t.setAttribute("aria-selected", !0), gt.reflow(t), ri(t).addClass(di), t.parentNode && ri(t.parentNode).hasClass(ci)) {
                    var r = ri(t).closest(pi)[0];
                    r && ri(r).find(Ei).addClass(fi), t.setAttribute("aria-expanded", !0)
                }
                n && n()
            }, i._jQueryInterface = function (n) {
                return this.each(function () {
                    var t = ri(this),
                        e = t.data(oi);
                    if (e || (e = new i(this), t.data(oi, e)), "string" == typeof n) {
                        if ("undefined" == typeof e[n]) throw new TypeError('No method named "' + n + '"');
                        e[n]()
                    }
                })
            }, s(i, null, [{
                key: "VERSION",
                get: function () {
                    return "4.1.1"
                }
            }]), i
        }(), ri(document).on(li.CLICK_DATA_API, vi, function (t) {
            t.preventDefault(), bi._jQueryInterface.call(ri(this), "show")
        }), ri.fn.tab = bi._jQueryInterface, ri.fn.tab.Constructor = bi, ri.fn.tab.noConflict = function () {
            return ri.fn.tab = ai, bi._jQueryInterface
        }, bi);
    ! function (t) {
        if ("undefined" == typeof t) throw new TypeError("Bootstrap's JavaScript requires jQuery. jQuery must be included before Bootstrap's JavaScript.");
        var e = t.fn.jquery.split(" ")[0].split(".");
        if (e[0] < 2 && e[1] < 9 || 1 === e[0] && 9 === e[1] && e[2] < 1 || 4 <= e[0]) throw new Error("Bootstrap's JavaScript requires at least jQuery v1.9.1 but less than v4.0.0")
    }(e), t.Util = gt, t.Alert = mt, t.Button = _t, t.Carousel = vt, t.Collapse = Et, t.Dropdown = Ti, t.Modal = Ci, t.Popover = Ii, t.Scrollspy = Di, t.Tab = Ai, t.Tooltip = wi, Object.defineProperty(t, "__esModule", {
        value: !0
    })
});
/*!
Waypoints - 4.0.1
Copyright © 2011-2016 Caleb Troughton
Licensed under the MIT license.
https://github.com/imakewebthings/waypoints/blob/master/licenses.txt
*/
! function () {
    "use strict";

    function t(o) {
        if (!o) throw new Error("No options passed to Waypoint constructor");
        if (!o.element) throw new Error("No element option passed to Waypoint constructor");
        if (!o.handler) throw new Error("No handler option passed to Waypoint constructor");
        this.key = "waypoint-" + e, this.options = t.Adapter.extend({}, t.defaults, o), this.element = this.options.element, this.adapter = new t.Adapter(this.element), this.callback = o.handler, this.axis = this.options.horizontal ? "horizontal" : "vertical", this.enabled = this.options.enabled, this.triggerPoint = null, this.group = t.Group.findOrCreate({
            name: this.options.group,
            axis: this.axis
        }), this.context = t.Context.findOrCreateByElement(this.options.context), t.offsetAliases[this.options.offset] && (this.options.offset = t.offsetAliases[this.options.offset]), this.group.add(this), this.context.add(this), i[this.key] = this, e += 1
    }
    var e = 0,
        i = {};
    t.prototype.queueTrigger = function (t) {
        this.group.queueTrigger(this, t)
    }, t.prototype.trigger = function (t) {
        this.enabled && this.callback && this.callback.apply(this, t)
    }, t.prototype.destroy = function () {
        this.context.remove(this), this.group.remove(this), delete i[this.key]
    }, t.prototype.disable = function () {
        return this.enabled = !1, this
    }, t.prototype.enable = function () {
        return this.context.refresh(), this.enabled = !0, this
    }, t.prototype.next = function () {
        return this.group.next(this)
    }, t.prototype.previous = function () {
        return this.group.previous(this)
    }, t.invokeAll = function (t) {
        var e = [];
        for (var o in i) e.push(i[o]);
        for (var n = 0, r = e.length; r > n; n++) e[n][t]()
    }, t.destroyAll = function () {
        t.invokeAll("destroy")
    }, t.disableAll = function () {
        t.invokeAll("disable")
    }, t.enableAll = function () {
        t.Context.refreshAll();
        for (var e in i) i[e].enabled = !0;
        return this
    }, t.refreshAll = function () {
        t.Context.refreshAll()
    }, t.viewportHeight = function () {
        return window.innerHeight || document.documentElement.clientHeight
    }, t.viewportWidth = function () {
        return document.documentElement.clientWidth
    }, t.adapters = [], t.defaults = {
        context: window,
        continuous: !0,
        enabled: !0,
        group: "default",
        horizontal: !1,
        offset: 0
    }, t.offsetAliases = {
        "bottom-in-view": function () {
            return this.context.innerHeight() - this.adapter.outerHeight()
        },
        "right-in-view": function () {
            return this.context.innerWidth() - this.adapter.outerWidth()
        }
    }, window.Waypoint = t
}(),
    function () {
        "use strict";

        function t(t) {
            window.setTimeout(t, 1e3 / 60)
        }

        function e(t) {
            this.element = t, this.Adapter = n.Adapter, this.adapter = new this.Adapter(t), this.key = "waypoint-context-" + i, this.didScroll = !1, this.didResize = !1, this.oldScroll = {
                x: this.adapter.scrollLeft(),
                y: this.adapter.scrollTop()
            }, this.waypoints = {
                vertical: {},
                horizontal: {}
            }, t.waypointContextKey = this.key, o[t.waypointContextKey] = this, i += 1, n.windowContext || (n.windowContext = !0, n.windowContext = new e(window)), this.createThrottledScrollHandler(), this.createThrottledResizeHandler()
        }
        var i = 0,
            o = {},
            n = window.Waypoint,
            r = window.onload;
        e.prototype.add = function (t) {
            var e = t.options.horizontal ? "horizontal" : "vertical";
            this.waypoints[e][t.key] = t, this.refresh()
        }, e.prototype.checkEmpty = function () {
            var t = this.Adapter.isEmptyObject(this.waypoints.horizontal),
                e = this.Adapter.isEmptyObject(this.waypoints.vertical),
                i = this.element == this.element.window;
            t && e && !i && (this.adapter.off(".waypoints"), delete o[this.key])
        }, e.prototype.createThrottledResizeHandler = function () {
            function t() {
                e.handleResize(), e.didResize = !1
            }
            var e = this;
            this.adapter.on("resize.waypoints", function () {
                e.didResize || (e.didResize = !0, n.requestAnimationFrame(t))
            })
        }, e.prototype.createThrottledScrollHandler = function () {
            function t() {
                e.handleScroll(), e.didScroll = !1
            }
            var e = this;
            this.adapter.on("scroll.waypoints", function () {
                (!e.didScroll || n.isTouch) && (e.didScroll = !0, n.requestAnimationFrame(t))
            })
        }, e.prototype.handleResize = function () {
            n.Context.refreshAll()
        }, e.prototype.handleScroll = function () {
            var t = {},
                e = {
                    horizontal: {
                        newScroll: this.adapter.scrollLeft(),
                        oldScroll: this.oldScroll.x,
                        forward: "right",
                        backward: "left"
                    },
                    vertical: {
                        newScroll: this.adapter.scrollTop(),
                        oldScroll: this.oldScroll.y,
                        forward: "down",
                        backward: "up"
                    }
                };
            for (var i in e) {
                var o = e[i],
                    n = o.newScroll > o.oldScroll,
                    r = n ? o.forward : o.backward;
                for (var s in this.waypoints[i]) {
                    var a = this.waypoints[i][s];
                    if (null !== a.triggerPoint) {
                        var l = o.oldScroll < a.triggerPoint,
                            h = o.newScroll >= a.triggerPoint,
                            p = l && h,
                            u = !l && !h;
                        (p || u) && (a.queueTrigger(r), t[a.group.id] = a.group)
                    }
                }
            }
            for (var c in t) t[c].flushTriggers();
            this.oldScroll = {
                x: e.horizontal.newScroll,
                y: e.vertical.newScroll
            }
        }, e.prototype.innerHeight = function () {
            return this.element == this.element.window ? n.viewportHeight() : this.adapter.innerHeight()
        }, e.prototype.remove = function (t) {
            delete this.waypoints[t.axis][t.key], this.checkEmpty()
        }, e.prototype.innerWidth = function () {
            return this.element == this.element.window ? n.viewportWidth() : this.adapter.innerWidth()
        }, e.prototype.destroy = function () {
            var t = [];
            for (var e in this.waypoints)
                for (var i in this.waypoints[e]) t.push(this.waypoints[e][i]);
            for (var o = 0, n = t.length; n > o; o++) t[o].destroy()
        }, e.prototype.refresh = function () {
            var t, e = this.element == this.element.window,
                i = e ? void 0 : this.adapter.offset(),
                o = {};
            this.handleScroll(), t = {
                horizontal: {
                    contextOffset: e ? 0 : i.left,
                    contextScroll: e ? 0 : this.oldScroll.x,
                    contextDimension: this.innerWidth(),
                    oldScroll: this.oldScroll.x,
                    forward: "right",
                    backward: "left",
                    offsetProp: "left"
                },
                vertical: {
                    contextOffset: e ? 0 : i.top,
                    contextScroll: e ? 0 : this.oldScroll.y,
                    contextDimension: this.innerHeight(),
                    oldScroll: this.oldScroll.y,
                    forward: "down",
                    backward: "up",
                    offsetProp: "top"
                }
            };
            for (var r in t) {
                var s = t[r];
                for (var a in this.waypoints[r]) {
                    var l, h, p, u, c, d = this.waypoints[r][a],
                        f = d.options.offset,
                        w = d.triggerPoint,
                        y = 0,
                        g = null == w;
                    d.element !== d.element.window && (y = d.adapter.offset()[s.offsetProp]), "function" == typeof f ? f = f.apply(d) : "string" == typeof f && (f = parseFloat(f), d.options.offset.indexOf("%") > -1 && (f = Math.ceil(s.contextDimension * f / 100))), l = s.contextScroll - s.contextOffset, d.triggerPoint = Math.floor(y + l - f), h = w < s.oldScroll, p = d.triggerPoint >= s.oldScroll, u = h && p, c = !h && !p, !g && u ? (d.queueTrigger(s.backward), o[d.group.id] = d.group) : !g && c ? (d.queueTrigger(s.forward), o[d.group.id] = d.group) : g && s.oldScroll >= d.triggerPoint && (d.queueTrigger(s.forward), o[d.group.id] = d.group)
                }
            }
            return n.requestAnimationFrame(function () {
                for (var t in o) o[t].flushTriggers()
            }), this
        }, e.findOrCreateByElement = function (t) {
            return e.findByElement(t) || new e(t)
        }, e.refreshAll = function () {
            for (var t in o) o[t].refresh()
        }, e.findByElement = function (t) {
            return o[t.waypointContextKey]
        }, window.onload = function () {
            r && r(), e.refreshAll()
        }, n.requestAnimationFrame = function (e) {
            var i = window.requestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame || t;
            i.call(window, e)
        }, n.Context = e
    }(),
    function () {
        "use strict";

        function t(t, e) {
            return t.triggerPoint - e.triggerPoint
        }

        function e(t, e) {
            return e.triggerPoint - t.triggerPoint
        }

        function i(t) {
            this.name = t.name, this.axis = t.axis, this.id = this.name + "-" + this.axis, this.waypoints = [], this.clearTriggerQueues(), o[this.axis][this.name] = this
        }
        var o = {
            vertical: {},
            horizontal: {}
        },
            n = window.Waypoint;
        i.prototype.add = function (t) {
            this.waypoints.push(t)
        }, i.prototype.clearTriggerQueues = function () {
            this.triggerQueues = {
                up: [],
                down: [],
                left: [],
                right: []
            }
        }, i.prototype.flushTriggers = function () {
            for (var i in this.triggerQueues) {
                var o = this.triggerQueues[i],
                    n = "up" === i || "left" === i;
                o.sort(n ? e : t);
                for (var r = 0, s = o.length; s > r; r += 1) {
                    var a = o[r];
                    (a.options.continuous || r === o.length - 1) && a.trigger([i])
                }
            }
            this.clearTriggerQueues()
        }, i.prototype.next = function (e) {
            this.waypoints.sort(t);
            var i = n.Adapter.inArray(e, this.waypoints),
                o = i === this.waypoints.length - 1;
            return o ? null : this.waypoints[i + 1]
        }, i.prototype.previous = function (e) {
            this.waypoints.sort(t);
            var i = n.Adapter.inArray(e, this.waypoints);
            return i ? this.waypoints[i - 1] : null
        }, i.prototype.queueTrigger = function (t, e) {
            this.triggerQueues[e].push(t)
        }, i.prototype.remove = function (t) {
            var e = n.Adapter.inArray(t, this.waypoints);
            e > -1 && this.waypoints.splice(e, 1)
        }, i.prototype.first = function () {
            return this.waypoints[0]
        }, i.prototype.last = function () {
            return this.waypoints[this.waypoints.length - 1]
        }, i.findOrCreate = function (t) {
            return o[t.axis][t.name] || new i(t)
        }, n.Group = i
    }(),
    function () {
        "use strict";

        function t(t) {
            this.$element = e(t)
        }
        var e = window.jQuery,
            i = window.Waypoint;
        e.each(["innerHeight", "innerWidth", "off", "offset", "on", "outerHeight", "outerWidth", "scrollLeft", "scrollTop"], function (e, i) {
            t.prototype[i] = function () {
                var t = Array.prototype.slice.call(arguments);
                return this.$element[i].apply(this.$element, t)
            }
        }), e.each(["extend", "inArray", "isEmptyObject"], function (i, o) {
            t[o] = e[o]
        }), i.adapters.push({
            name: "jquery",
            Adapter: t
        }), i.Adapter = t
    }(),
    function () {
        "use strict";

        function t(t) {
            return function () {
                var i = [],
                    o = arguments[0];
                return t.isFunction(arguments[0]) && (o = t.extend({}, arguments[1]), o.handler = arguments[0]), this.each(function () {
                    var n = t.extend({}, o, {
                        element: this
                    });
                    "string" == typeof n.context && (n.context = t(this).closest(n.context)[0]), i.push(new e(n))
                }), i
            }
        }
        var e = window.Waypoint;
        window.jQuery && (window.jQuery.fn.waypoint = t(window.jQuery)), window.Zepto && (window.Zepto.fn.waypoint = t(window.Zepto))
    }();
(function (h) {
    h.easing.jswing = h.easing.swing;
    h.extend(h.easing, {
        def: "easeOutQuad",
        swing: function (e, a, c, b, d) {
            return h.easing[h.easing.def](e, a, c, b, d)
        },
        easeInQuad: function (e, a, c, b, d) {
            return b * (a /= d) * a + c
        },
        easeOutQuad: function (e, a, c, b, d) {
            return -b * (a /= d) * (a - 2) + c
        },
        easeInOutQuad: function (e, a, c, b, d) {
            return 1 > (a /= d / 2) ? b / 2 * a * a + c : -b / 2 * (--a * (a - 2) - 1) + c
        },
        easeInCubic: function (e, a, c, b, d) {
            return b * (a /= d) * a * a + c
        },
        easeOutCubic: function (e, a, c, b, d) {
            return b * ((a = a / d - 1) * a * a + 1) + c
        },
        easeInOutCubic: function (e, a, c, b, d) {
            return 1 > (a /= d / 2) ? b / 2 * a * a * a + c : b / 2 * ((a -= 2) * a * a + 2) + c
        },
        easeInQuart: function (e, a, c, b, d) {
            return b * (a /= d) * a * a * a + c
        },
        easeOutQuart: function (e, a, c, b, d) {
            return -b * ((a = a / d - 1) * a * a * a - 1) + c
        },
        easeInOutQuart: function (e, a, c, b, d) {
            return 1 > (a /= d / 2) ? b / 2 * a * a * a * a + c : -b / 2 * ((a -= 2) * a * a * a - 2) + c
        },
        easeInQuint: function (e, a, c, b, d) {
            return b * (a /= d) * a * a * a * a + c
        },
        easeOutQuint: function (e, a, c, b, d) {
            return b * ((a = a / d - 1) * a * a * a * a + 1) + c
        },
        easeInOutQuint: function (e, a, c, b, d) {
            return 1 > (a /= d / 2) ? b / 2 * a * a * a * a * a + c : b / 2 * ((a -= 2) * a * a * a * a + 2) + c
        },
        easeInSine: function (e, a, c, b, d) {
            return -b * Math.cos(a / d * (Math.PI / 2)) + b + c
        },
        easeOutSine: function (e, a, c, b, d) {
            return b * Math.sin(a / d * (Math.PI / 2)) + c
        },
        easeInOutSine: function (e, a, c, b, d) {
            return -b / 2 * (Math.cos(Math.PI * a / d) - 1) + c
        },
        easeInExpo: function (e, a, c, b, d) {
            return 0 == a ? c : b * Math.pow(2, 10 * (a / d - 1)) + c
        },
        easeOutExpo: function (e, a, c, b, d) {
            return a == d ? c + b : b * (-Math.pow(2, -10 * a / d) + 1) + c
        },
        easeInOutExpo: function (e, a, c, b, d) {
            return 0 == a ? c : a == d ? c + b : 1 > (a /= d / 2) ? b / 2 * Math.pow(2, 10 * (a - 1)) + c : b / 2 * (-Math.pow(2, -10 * --a) + 2) + c
        },
        easeInCirc: function (e, a, c, b, d) {
            return -b * (Math.sqrt(1 - (a /= d) * a) - 1) + c
        },
        easeOutCirc: function (e, a, c, b, d) {
            return b * Math.sqrt(1 - (a = a / d - 1) * a) + c
        },
        easeInOutCirc: function (e, a, c, b, d) {
            return 1 > (a /= d / 2) ? -b / 2 * (Math.sqrt(1 - a * a) - 1) + c : b / 2 * (Math.sqrt(1 - (a -= 2) * a) + 1) + c
        },
        easeInElastic: function (e, a, c, b, d) {
            e = 1.70158;
            var f = 0,
                g = b;
            if (0 == a) return c;
            if (1 == (a /= d)) return c + b;
            f || (f = .3 * d);
            g < Math.abs(b) ? (g = b, e = f / 4) : e = f / (2 * Math.PI) * Math.asin(b / g);
            return -(g * Math.pow(2, 10 * --a) * Math.sin(2 * (a * d - e) * Math.PI / f)) + c
        },
        easeOutElastic: function (e, a, c, b, d) {
            e = 1.70158;
            var f = 0,
                g = b;
            if (0 == a) return c;
            if (1 == (a /= d)) return c + b;
            f || (f = .3 * d);
            g < Math.abs(b) ? (g = b, e = f / 4) : e = f / (2 * Math.PI) * Math.asin(b / g);
            return g * Math.pow(2, -10 * a) * Math.sin(2 * (a * d - e) * Math.PI / f) + b + c
        },
        easeInOutElastic: function (e, a, c, b, d) {
            e = 1.70158;
            var f = 0,
                g = b;
            if (0 == a) return c;
            if (2 == (a /= d / 2)) return c + b;
            f || (f = .3 * d * 1.5);
            g < Math.abs(b) ? (g = b, e = f / 4) : e = f / (2 * Math.PI) * Math.asin(b / g);
            return 1 > a ? -.5 * g * Math.pow(2, 10 * --a) * Math.sin(2 * (a * d - e) * Math.PI / f) + c : g * Math.pow(2, -10 * --a) * Math.sin(2 * (a * d - e) * Math.PI / f) * .5 + b + c
        },
        easeInBack: function (e, a, c, b, d, f) {
            void 0 == f && (f = 1.70158);
            return b * (a /= d) * a * ((f + 1) * a - f) + c
        },
        easeOutBack: function (e, a, c, b, d, f) {
            void 0 == f && (f = 1.70158);
            return b * ((a = a / d - 1) * a * ((f + 1) * a + f) + 1) + c
        },
        easeInOutBack: function (e, a, c, b, d, f) {
            void 0 == f && (f = 1.70158);
            return 1 > (a /= d / 2) ? b / 2 * a * a * (((f *= 1.525) + 1) * a - f) + c : b / 2 * ((a -= 2) * a * (((f *= 1.525) + 1) * a + f) + 2) + c
        },
        easeInBounce: function (e, a, c, b, d) {
            return b - h.easing.easeOutBounce(e, d - a, 0, b, d) + c
        },
        easeOutBounce: function (e, a, c, b, d) {
            return (a /= d) < 1 / 2.75 ? 7.5625 * b * a * a + c : a < 2 / 2.75 ? b * (7.5625 * (a -= 1.5 / 2.75) * a + .75) + c : a < 2.5 / 2.75 ? b * (7.5625 * (a -= 2.25 / 2.75) * a + .9375) + c : b * (7.5625 * (a -= 2.625 / 2.75) * a + .984375) + c
        },
        easeInOutBounce: function (e, a, c, b, d) {
            return a < d / 2 ? .5 * h.easing.easeInBounce(e, 2 * a, 0, b, d) + c : .5 * h.easing.easeOutBounce(e, 2 * a - d, 0, b, d) + .5 * b + c
        }
    })
})(jQuery);
! function (a, b, c) {
    a.fn.scrollUp = function (b) {
        a.data(c.body, "scrollUp") || (a.data(c.body, "scrollUp", !0), a.fn.scrollUp.init(b))
    }, a.fn.scrollUp.init = function (d) {
        var e = a.fn.scrollUp.settings = a.extend({}, a.fn.scrollUp.defaults, d),
            f = (e.scrollTitle ? e.scrollTitle : e.scrollText, a("<a/>", {
                id: e.scrollName,
                href: "#top"
            }).appendTo("body"));
        e.scrollImg || f.html(e.scrollText), f.css({
            display: "none",
            position: "fixed",
            zIndex: e.zIndex
        }), e.activeOverlay && a("<div/>", {
            id: e.scrollName + "-active"
        }).css({
            position: "absolute",
            top: e.scrollDistance + "px",
            width: "100%",
            borderTop: "1px dotted" + e.activeOverlay,
            zIndex: e.zIndex
        }).appendTo("body"), scrollEvent = a(b).scroll(function () {
            switch (scrollDis = "top" === e.scrollFrom ? e.scrollDistance : a(c).height() - a(b).height() - e.scrollDistance, e.animation) {
                case "fade":
                    a(a(b).scrollTop() > scrollDis ? f.fadeIn(e.animationInSpeed) : f.fadeOut(e.animationOutSpeed));
                    break;
                case "slide":
                    a(a(b).scrollTop() > scrollDis ? f.slideDown(e.animationInSpeed) : f.slideUp(e.animationOutSpeed));
                    break;
                default:
                    a(a(b).scrollTop() > scrollDis ? f.show(0) : f.hide(0))
            }
        }), f.click(function (b) {
            b.preventDefault(), a("html, body").animate({
                scrollTop: 0
            }, e.scrollSpeed, e.easingType)
        })
    }, a.fn.scrollUp.defaults = {
        scrollName: "scrollUp",
        scrollDistance: 300,
        scrollFrom: "top",
        scrollSpeed: 300,
        easingType: "linear",
        animation: "fade",
        animationInSpeed: 200,
        animationOutSpeed: 200,
        scrollText: "Scroll to top",
        scrollTitle: !1,
        scrollImg: !1,
        activeOverlay: !1,
        zIndex: 2147483647
    }, a.fn.scrollUp.destroy = function (d) {
        a.removeData(c.body, "scrollUp"), a("#" + a.fn.scrollUp.settings.scrollName).remove(), a("#" + a.fn.scrollUp.settings.scrollName + "-active").remove(), a.fn.jquery.split(".")[1] >= 7 ? a(b).off("scroll", d) : a(b).unbind("scroll", d)
    }, a.scrollUp = a.fn.scrollUp
}(jQuery, window, document),
    function (a) {
        "use strict";
        a(document).ready(function () {
            a.scrollUp({
                scrollName: "scrollUp",
                scrollDistance: 300,
                scrollFrom: "top",
                scrollSpeed: 1e3,
                easingType: "easeInOutCubic",
                animation: "fade",
                animationInSpeed: 200,
                animationOutSpeed: 200,
                scrollText: "<i class='fas fa-angle-up'></i>",
                scrollTitle: " ",
                scrollImg: 0,
                activeOverlay: 0,
                zIndex: 1001
            })
        }), a(document).ready(function () {
            a("a.scrollTo").click(function () {
                return a("html, body").animate({
                    scrollTop: a(a(this).attr("href")).offset().top + "px"
                }, {
                        duration: 1e3,
                        easing: "easeInOutCubic"
                    }), !1
            })
        })
    }(jQuery);
window.Readmore = function (o) {
    var n = {};

    function r(e) {
        if (n[e]) return n[e].exports;
        var t = n[e] = {
            i: e,
            l: !1,
            exports: {}
        };
        return o[e].call(t.exports, t, t.exports, r), t.l = !0, t.exports
    }
    return r.m = o, r.c = n, r.d = function (e, t, o) {
        r.o(e, t) || Object.defineProperty(e, t, {
            configurable: !1,
            enumerable: !0,
            get: o
        })
    }, r.n = function (e) {
        var t = e && e.__esModule ? function () {
            return e.default
        } : function () {
            return e
        };
        return r.d(t, "a", t), t
    }, r.o = function (e, t) {
        return Object.prototype.hasOwnProperty.call(e, t)
    }, r.p = "", r(r.s = 0)
}([function (e, t, o) {
    e.exports = o(1)
}, function (e, t, o) {
    "use strict";
    Object.defineProperty(t, "__esModule", {
        value: !0
    });
    var n = function () {
        function n(e, t) {
            for (var o = 0; o < t.length; o++) {
                var n = t[o];
                n.enumerable = n.enumerable || !1, n.configurable = !0, "value" in n && (n.writable = !0), Object.defineProperty(e, n.key, n)
            }
        }
        return function (e, t, o) {
            return t && n(e.prototype, t), o && n(e, o), e
        }
    }(),
        c = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (e) {
            return typeof e
        } : function (e) {
            return e && "function" == typeof Symbol && e.constructor === Symbol && e !== Symbol.prototype ? "symbol" : typeof e
        };
    var a = 0,
        s = [];

    function l(e) {
        e.style.height = "auto";
        var t = parseInt(e.getBoundingClientRect().height, 10),
            o = parseInt(window.getComputedStyle(e).maxHeight, 10),
            n = parseInt(e.readmore.defaultHeight, 10);
        e.readmore.expandedHeight = t, e.readmore.maxHeight = o, e.readmore.collapsedHeight = o || e.readmore.collapsedHeight || n, e.style.maxHeight = "none"
    }

    function u(e, t, o) {
        var n, r, i = (n = e, (r = document.createElement("div")).innerHTML = n, r.firstChild);
        return i.setAttribute("data-readmore-toggle", t.id), i.setAttribute("aria-controls", t.id), i.addEventListener("click", function (e) {
            this.toggle(e.target, t, e)
        }.bind(o)), i
    }
    var i, d, f, p, r = (i = function () {
        document.querySelectorAll("[data-readmore]").forEach(function (e) {
            var t = "true" === e.getAttribute("aria-expanded");
            l(e), e.style.height = (t ? e.readmore.expandedHeight : e.readmore.collapsedHeight) + "px"
        })
    }, d = 100, p = void 0, function () {
        for (var e = this, t = arguments.length, o = Array(t), n = 0; n < t; n++) o[n] = arguments[n];
        var r = f && !p;
        clearTimeout(p), p = setTimeout(function () {
            p = null, f || i.apply(e, o)
        }, d), r && i.apply(this, o)
    }),
        h = {
            speed: 100,
            collapsedHeight: 200,
            heightMargin: 16,
            moreLink: '<a href="#">Read More</a>',
            lessLink: '<a href="#">Close</a>',
            embedCSS: !0,
            blockCSS: "display: block; width: 100%;",
            startOpen: !1,
            blockProcessed: function () { },
            beforeToggle: function () { },
            afterToggle: function () { }
        },
        g = function () {
            function o(e, t) {
                var i = this;
                ! function (e, t) {
                    if (!(e instanceof t)) throw new TypeError("Cannot call a class as a function")
                }(this, o), "undefined" != typeof window && "undefined" != typeof document && document.querySelectorAll && window.addEventListener && (this.options = function t() {
                    for (var o = {}.hasOwnProperty, e = arguments.length, n = Array(e), r = 0; r < e; r++) n[r] = arguments[r];
                    var i = n[0],
                        a = n[1];
                    if (2 < n.length) {
                        var s = [];
                        for (n.forEach(function (e) {
                            s.push(e)
                        }); 2 < s.length;) {
                            var l = s.shift(),
                                d = s.shift();
                            s.unshift(t(l, d))
                        }
                        i = s.shift(), a = s.shift()
                    }
                    return Object.keys(a).forEach(function (e) {
                        o.call(a, e) && ("object" === c(a[e]) ? (i[e] = i[e] || {}, i[e] = t(i[e], a[e])) : i[e] = a[e])
                    }), i
                }({}, h, t), this.options.selector = e, function (e) {
                    if (!s[e.selector]) {
                        var t = " ";
                        e.embedCSS && "" !== e.blockCSS && (t += e.selector + " + [data-readmore-toggle], " + e.selector + "[data-readmore] {\n        " + e.blockCSS + "\n      }"), t += e.selector + "[data-readmore] {\n      transition: height " + e.speed + "ms;\n      overflow: hidden;\n    }", o = document, n = t, (r = o.createElement("style")).type = "text/css", r.styleSheet ? r.styleSheet.cssText = n : r.appendChild(o.createTextNode(n)), o.getElementsByTagName("head")[0].appendChild(r), s[e.selector] = !0
                    }
                    var o, n, r
                }(this.options), window.addEventListener("load", r), window.addEventListener("resize", r), document.querySelectorAll(e).forEach(function (e) {
                    var t = i.options.startOpen;
                    e.readmore = {
                        defaultHeight: i.options.collapsedHeight,
                        heightMargin: i.options.heightMargin
                    }, l(e);
                    var o = e.readmore.heightMargin;
                    if (e.getBoundingClientRect().height <= e.readmore.collapsedHeight + o) "function" == typeof i.options.blockProcessed && i.options.blockProcessed(e, !1);
                    else {
                        var n = e.id || function () {
                            return "" + (0 < arguments.length && void 0 !== arguments[0] ? arguments[0] : "rmjs-") + (a += 1)
                        }();
                        e.setAttribute("data-readmore", ""), e.setAttribute("aria-expanded", t), e.id = n;
                        var r = t ? i.options.lessLink : i.options.moreLink;
                        e.parentNode.insertBefore(u(r, e, i), e.nextSibling), e.style.height = (t ? e.readmore.expandedHeight : e.readmore.collapsedHeight) + "px", "function" == typeof i.options.blockProcessed && i.options.blockProcessed(e, !0)
                    }
                }, this))
            }
            return n(o, [{
                key: "toggle",
                value: function () {
                    for (var o = this, e = arguments.length, t = Array(e), n = 0; n < e; n++) t[n] = arguments[n];
                    var r = t[1] || t.shift();
                    if ("string" == typeof r && (r = document.querySelector(r)), null === r) throw new Error("Element MUST be either an HTML node or querySelector string");
                    var i = t[0] || document.querySelector('[aria-controls="' + r.id + '"]'),
                        a = t[2];
                    a && (a.preventDefault(), a.stopPropagation());
                    var s = r.getBoundingClientRect().height <= r.readmore.collapsedHeight,
                        l = s ? r.readmore.expandedHeight : r.readmore.collapsedHeight;
                    "function" == typeof this.options.beforeToggle && this.options.beforeToggle(i, r, !s), r.style.height = l + "px";
                    var d = function e(t) {
                        "function" == typeof o.options.afterToggle && o.options.afterToggle(i, r, s), t.stopPropagation(), r.setAttribute("aria-expanded", s), r.removeEventListener("transitionend", e, !1)
                    };
                    r.addEventListener("transitionend", d, !1), this.options.speed < 1 && d.call(this, {
                        target: r
                    });
                    var c = s ? this.options.lessLink : this.options.moreLink;
                    i.parentNode.replaceChild(u(c, r, this), i)
                }
            }, {
                key: "destroy",
                value: function () {
                    console.warn(this)
                }
            }]), o
        }();
    g.VERSION = "3.0.0-alpha-2", t.default = g
}]).default;
! function (t, e) {
    "object" == typeof exports && "undefined" != typeof module ? module.exports = e() : "function" == typeof define && define.amd ? define(e) : (t = t || self).SimpleBar = e()
}(this, function () {
    "use strict";
    var n = function (t) {
        return "object" == typeof t ? null !== t : "function" == typeof t
    },
        O = function (t) {
            if (!n(t)) throw TypeError(t + " is not an object!");
            return t
        },
        u = function (t) {
            if (null == t) throw TypeError("Can't call method on  " + t);
            return t
        },
        d = function (t) {
            return Object(u(t))
        },
        e = Math.ceil,
        i = Math.floor,
        S = function (t) {
            return isNaN(t = +t) ? 0 : (0 < t ? i : e)(t)
        },
        r = Math.min,
        k = function (t) {
            return 0 < t ? r(S(t), 9007199254740991) : 0
        },
        t = function (a) {
            return function (t, e) {
                var i, r, n = String(u(t)),
                    o = S(e),
                    s = n.length;
                return o < 0 || s <= o ? a ? "" : void 0 : (i = n.charCodeAt(o)) < 55296 || 56319 < i || o + 1 === s || (r = n.charCodeAt(o + 1)) < 56320 || 57343 < r ? a ? n.charAt(o) : i : a ? n.slice(o, o + 2) : r - 56320 + (i - 55296 << 10) + 65536
            }
        },
        o = t(!0),
        A = function (t, e, i) {
            return e + (i ? o(t, e).length : 1)
        },
        s = {}.toString,
        a = function (t) {
            return s.call(t).slice(8, -1)
        },
        l = "undefined" != typeof window ? window : "undefined" != typeof global ? global : "undefined" != typeof self ? self : {};

    function c(t, e) {
        return t(e = {
            exports: {}
        }, e.exports), e.exports
    }
    var h, f, v = c(function (t) {
        var e = t.exports = {
            version: "2.6.2"
        };
        "number" == typeof __e && (__e = e)
    }),
        b = (v.version, c(function (t) {
            var e = t.exports = "undefined" != typeof window && window.Math == Math ? window : "undefined" != typeof self && self.Math == Math ? self : Function("return this")();
            "number" == typeof __g && (__g = e)
        })),
        p = c(function (t) {
            var e = "__core-js_shared__",
                i = b[e] || (b[e] = {});
            (t.exports = function (t, e) {
                return i[t] || (i[t] = void 0 !== e ? e : {})
            })("versions", []).push({
                version: v.version,
                mode: "global",
                copyright: "© 2019 Denis Pushkarev (zloirock.ru)"
            })
        }),
        y = 0,
        g = Math.random(),
        m = function (t) {
            return "Symbol(".concat(void 0 === t ? "" : t, ")_", (++y + g).toString(36))
        },
        x = c(function (t) {
            var e = p("wks"),
                i = b.Symbol,
                r = "function" == typeof i;
            (t.exports = function (t) {
                return e[t] || (e[t] = r && i[t] || (r ? i : m)("Symbol." + t))
            }).store = e
        }),
        E = x("toStringTag"),
        w = "Arguments" == a(function () {
            return arguments
        }()),
        _ = function (t) {
            var e, i, r;
            return void 0 === t ? "Undefined" : null === t ? "Null" : "string" == typeof (i = function (t, e) {
                try {
                    return t[e]
                } catch (t) { }
            }(e = Object(t), E)) ? i : w ? a(e) : "Object" == (r = a(e)) && "function" == typeof e.callee ? "Arguments" : r
        },
        M = RegExp.prototype.exec,
        L = function (t, e) {
            var i = t.exec;
            if ("function" == typeof i) {
                var r = i.call(t, e);
                if ("object" != typeof r) throw new TypeError("RegExp exec method returned something other than an Object or null");
                return r
            }
            if ("RegExp" !== _(t)) throw new TypeError("RegExp#exec called on incompatible receiver");
            return M.call(t, e)
        },
        T = RegExp.prototype.exec,
        j = String.prototype.replace,
        R = T,
        N = "lastIndex",
        W = (h = /a/, f = /b*/g, T.call(h, "a"), T.call(f, "a"), 0 !== h[N] || 0 !== f[N]),
        C = void 0 !== /()??/.exec("")[1];
    (W || C) && (R = function (t) {
        var e, i, r, n, o = this;
        return C && (i = new RegExp("^" + o.source + "$(?!\\s)", function () {
            var t = O(this),
                e = "";
            return t.global && (e += "g"), t.ignoreCase && (e += "i"), t.multiline && (e += "m"), t.unicode && (e += "u"), t.sticky && (e += "y"), e
        }.call(o))), W && (e = o[N]), r = T.call(o, t), W && r && (o[N] = o.global ? r.index + r[0].length : e), C && r && 1 < r.length && j.call(r[0], i, function () {
            for (n = 1; n < arguments.length - 2; n++) void 0 === arguments[n] && (r[n] = void 0)
        }), r
    });
    var z = R,
        D = function (t) {
            try {
                return !!t()
            } catch (t) {
                return !0
            }
        },
        V = !D(function () {
            return 7 != Object.defineProperty({}, "a", {
                get: function () {
                    return 7
                }
            }).a
        }),
        B = b.document,
        P = n(B) && n(B.createElement),
        F = function (t) {
            return P ? B.createElement(t) : {}
        },
        H = !V && !D(function () {
            return 7 != Object.defineProperty(F("div"), "a", {
                get: function () {
                    return 7
                }
            }).a
        }),
        I = Object.defineProperty,
        q = {
            f: V ? Object.defineProperty : function (t, e, i) {
                if (O(t), e = function (t, e) {
                    if (!n(t)) return t;
                    var i, r;
                    if (e && "function" == typeof (i = t.toString) && !n(r = i.call(t))) return r;
                    if ("function" == typeof (i = t.valueOf) && !n(r = i.call(t))) return r;
                    if (!e && "function" == typeof (i = t.toString) && !n(r = i.call(t))) return r;
                    throw TypeError("Can't convert object to primitive value")
                }(e, !0), O(i), H) try {
                    return I(t, e, i)
                } catch (t) { }
                if ("get" in i || "set" in i) throw TypeError("Accessors not supported!");
                return "value" in i && (t[e] = i.value), t
            }
        },
        $ = function (t, e) {
            return {
                enumerable: !(1 & t),
                configurable: !(2 & t),
                writable: !(4 & t),
                value: e
            }
        },
        X = V ? function (t, e, i) {
            return q.f(t, e, $(1, i))
        } : function (t, e, i) {
            return t[e] = i, t
        },
        Y = {}.hasOwnProperty,
        G = function (t, e) {
            return Y.call(t, e)
        },
        U = c(function (t) {
            var o = m("src"),
                e = "toString",
                i = Function[e],
                s = ("" + i).split(e);
            v.inspectSource = function (t) {
                return i.call(t)
            }, (t.exports = function (t, e, i, r) {
                var n = "function" == typeof i;
                n && (G(i, "name") || X(i, "name", e)), t[e] !== i && (n && (G(i, o) || X(i, o, t[e] ? "" + t[e] : s.join(String(e)))), t === b ? t[e] = i : r ? t[e] ? t[e] = i : X(t, e, i) : (delete t[e], X(t, e, i)))
            })(Function.prototype, e, function () {
                return "function" == typeof this && this[o] || i.call(this)
            })
        }),
        J = function (r, n, t) {
            if (function (t) {
                if ("function" != typeof t) throw TypeError(t + " is not a function!")
            }(r), void 0 === n) return r;
            switch (t) {
                case 1:
                    return function (t) {
                        return r.call(n, t)
                    };
                case 2:
                    return function (t, e) {
                        return r.call(n, t, e)
                    };
                case 3:
                    return function (t, e, i) {
                        return r.call(n, t, e, i)
                    }
            }
            return function () {
                return r.apply(n, arguments)
            }
        },
        K = "prototype",
        Q = function (t, e, i) {
            var r, n, o, s, a = t & Q.F,
                l = t & Q.G,
                c = t & Q.S,
                u = t & Q.P,
                h = t & Q.B,
                f = l ? b : c ? b[e] || (b[e] = {}) : (b[e] || {})[K],
                d = l ? v : v[e] || (v[e] = {}),
                p = d[K] || (d[K] = {});
            for (r in l && (i = e), i) o = ((n = !a && f && void 0 !== f[r]) ? f : i)[r], s = h && n ? J(o, b) : u && "function" == typeof o ? J(Function.call, o) : o, f && U(f, r, o, t & Q.U), d[r] != o && X(d, r, s), u && p[r] != o && (p[r] = o)
        };
    b.core = v, Q.F = 1, Q.G = 2, Q.S = 4, Q.P = 8, Q.B = 16, Q.W = 32, Q.U = 64, Q.R = 128;
    var Z = Q;
    Z({
        target: "RegExp",
        proto: !0,
        forced: z !== /./.exec
    }, {
            exec: z
        });
    var tt = x("species"),
        et = !D(function () {
            var t = /./;
            return t.exec = function () {
                var t = [];
                return t.groups = {
                    a: "7"
                }, t
            }, "7" !== "".replace(t, "$<a>")
        }),
        it = function () {
            var t = /(?:)/,
                e = t.exec;
            t.exec = function () {
                return e.apply(this, arguments)
            };
            var i = "ab".split(t);
            return 2 === i.length && "a" === i[0] && "b" === i[1]
        }(),
        rt = function (i, t, e) {
            var r = x(i),
                o = !D(function () {
                    var t = {};
                    return t[r] = function () {
                        return 7
                    }, 7 != ""[i](t)
                }),
                n = o ? !D(function () {
                    var t = !1,
                        e = /a/;
                    return e.exec = function () {
                        return t = !0, null
                    }, "split" === i && (e.constructor = {}, e.constructor[tt] = function () {
                        return e
                    }), e[r](""), !t
                }) : void 0;
            if (!o || !n || "replace" === i && !et || "split" === i && !it) {
                var s = /./[r],
                    a = e(u, r, ""[i], function (t, e, i, r, n) {
                        return e.exec === z ? o && !n ? {
                            done: !0,
                            value: s.call(e, i, r)
                        } : {
                                done: !0,
                                value: t.call(i, e, r)
                            } : {
                                done: !1
                            }
                    }),
                    l = a[0],
                    c = a[1];
                U(String.prototype, i, l), X(RegExp.prototype, r, 2 == t ? function (t, e) {
                    return c.call(t, this, e)
                } : function (t) {
                    return c.call(t, this)
                })
            }
        },
        nt = Math.max,
        ot = Math.min,
        st = Math.floor,
        at = /\$([$&`']|\d\d?|<[^>]*>)/g,
        lt = /\$([$&`']|\d\d?)/g;
    rt("replace", 2, function (n, o, E, w) {
        return [function (t, e) {
            var i = n(this),
                r = null == t ? void 0 : t[o];
            return void 0 !== r ? r.call(t, i, e) : E.call(String(i), t, e)
        }, function (t, e) {
            var i = w(E, t, this, e);
            if (i.done) return i.value;
            var r = O(t),
                n = String(this),
                o = "function" == typeof e;
            o || (e = String(e));
            var s = r.global;
            if (s) {
                var a = r.unicode;
                r.lastIndex = 0
            }
            for (var l = []; ;) {
                var c = L(r, n);
                if (null === c) break;
                if (l.push(c), !s) break;
                "" === String(c[0]) && (r.lastIndex = A(n, k(r.lastIndex), a))
            }
            for (var u, h = "", f = 0, d = 0; d < l.length; d++) {
                c = l[d];
                for (var p = String(c[0]), v = nt(ot(S(c.index), n.length), 0), b = [], y = 1; y < c.length; y++) b.push(void 0 === (u = c[y]) ? u : String(u));
                var g = c.groups;
                if (o) {
                    var m = [p].concat(b, v, n);
                    void 0 !== g && m.push(g);
                    var x = String(e.apply(void 0, m))
                } else x = _(p, n, v, b, g, e);
                f <= v && (h += n.slice(f, v) + x, f = v + p.length)
            }
            return h + n.slice(f)
        }];

        function _(o, s, a, l, c, t) {
            var u = a + o.length,
                h = l.length,
                e = lt;
            return void 0 !== c && (c = d(c), e = at), E.call(t, e, function (t, e) {
                var i;
                switch (e.charAt(0)) {
                    case "$":
                        return "$";
                    case "&":
                        return o;
                    case "`":
                        return s.slice(0, a);
                    case "'":
                        return s.slice(u);
                    case "<":
                        i = c[e.slice(1, -1)];
                        break;
                    default:
                        var r = +e;
                        if (0 === r) return t;
                        if (h < r) {
                            var n = st(r / 10);
                            return 0 === n ? t : n <= h ? void 0 === l[n - 1] ? e.charAt(1) : l[n - 1] + e.charAt(1) : t
                        }
                        i = l[r - 1]
                }
                return void 0 === i ? "" : i
            })
        }
    });
    var ct = q.f,
        ut = Function.prototype,
        ht = /^\s*function ([^ (]*)/;
    "name" in ut || V && ct(ut, "name", {
        configurable: !0,
        get: function () {
            try {
                return ("" + this).match(ht)[1]
            } catch (t) {
                return ""
            }
        }
    }), rt("match", 1, function (r, n, c, u) {
        return [function (t) {
            var e = r(this),
                i = null == t ? void 0 : t[n];
            return void 0 !== i ? i.call(t, e) : new RegExp(t)[n](String(e))
        }, function (t) {
            var e = u(c, t, this);
            if (e.done) return e.value;
            var i = O(t),
                r = String(this);
            if (!i.global) return L(i, r);
            for (var n, o = i.unicode, s = [], a = i.lastIndex = 0; null !== (n = L(i, r));) {
                var l = String(n[0]);
                "" === (s[a] = l) && (i.lastIndex = A(r, k(i.lastIndex), o)), a++
            }
            return 0 === a ? null : s
        }]
    });
    var ft = x("unscopables"),
        dt = Array.prototype;
    null == dt[ft] && X(dt, ft, {});
    var pt, vt = function (t) {
        dt[ft][t] = !0
    },
        bt = function (t, e) {
            return {
                value: e,
                done: !!t
            }
        },
        yt = {},
        gt = Object("z").propertyIsEnumerable(0) ? Object : function (t) {
            return "String" == a(t) ? t.split("") : Object(t)
        },
        mt = function (t) {
            return gt(u(t))
        },
        xt = Math.max,
        Et = Math.min,
        wt = p("keys"),
        _t = function (t) {
            return wt[t] || (wt[t] = m(t))
        },
        Ot = (pt = !1, function (t, e, i) {
            var r, n, o, s = mt(t),
                a = k(s.length),
                l = (n = a, (r = S(r = i)) < 0 ? xt(r + n, 0) : Et(r, n));
            if (pt && e != e) {
                for (; l < a;)
                    if ((o = s[l++]) != o) return !0
            } else
                for (; l < a; l++)
                    if ((pt || l in s) && s[l] === e) return pt || l || 0; return !pt && -1
        }),
        St = _t("IE_PROTO"),
        kt = "constructor,hasOwnProperty,isPrototypeOf,propertyIsEnumerable,toLocaleString,toString,valueOf".split(","),
        At = Object.keys || function (t) {
            return function (t, e) {
                var i, r = mt(t),
                    n = 0,
                    o = [];
                for (i in r) i != St && G(r, i) && o.push(i);
                for (; e.length > n;) G(r, i = e[n++]) && (~Ot(o, i) || o.push(i));
                return o
            }(t, kt)
        },
        Mt = V ? Object.defineProperties : function (t, e) {
            O(t);
            for (var i, r = At(e), n = r.length, o = 0; o < n;) q.f(t, i = r[o++], e[i]);
            return t
        },
        Lt = b.document,
        Tt = Lt && Lt.documentElement,
        jt = _t("IE_PROTO"),
        Rt = function () { },
        Nt = "prototype",
        Wt = function () {
            var t, e = F("iframe"),
                i = kt.length;
            for (e.style.display = "none", Tt.appendChild(e), e.src = "javascript:", (t = e.contentWindow.document).open(), t.write("<script>document.F=Object<\/script>"), t.close(), Wt = t.F; i--;) delete Wt[Nt][kt[i]];
            return Wt()
        },
        Ct = Object.create || function (t, e) {
            var i;
            return null !== t ? (Rt[Nt] = O(t), i = new Rt, Rt[Nt] = null, i[jt] = t) : i = Wt(), void 0 === e ? i : Mt(i, e)
        },
        zt = q.f,
        Dt = x("toStringTag"),
        Vt = function (t, e, i) {
            t && !G(t = i ? t : t.prototype, Dt) && zt(t, Dt, {
                configurable: !0,
                value: e
            })
        },
        Bt = {};
    X(Bt, x("iterator"), function () {
        return this
    });
    var Pt = _t("IE_PROTO"),
        Ft = Object.prototype,
        Ht = Object.getPrototypeOf || function (t) {
            return t = d(t), G(t, Pt) ? t[Pt] : "function" == typeof t.constructor && t instanceof t.constructor ? t.constructor.prototype : t instanceof Object ? Ft : null
        },
        It = x("iterator"),
        qt = !([].keys && "next" in [].keys()),
        $t = "values",
        Xt = function () {
            return this
        },
        Yt = function (t, e, i, r, n, o, s) {
            var a, l, c;
            l = e, c = r, (a = i).prototype = Ct(Bt, {
                next: $(1, c)
            }), Vt(a, l + " Iterator");
            var u, h, f, d = function (t) {
                if (!qt && t in y) return y[t];
                switch (t) {
                    case "keys":
                    case $t:
                        return function () {
                            return new i(this, t)
                        }
                }
                return function () {
                    return new i(this, t)
                }
            },
                p = e + " Iterator",
                v = n == $t,
                b = !1,
                y = t.prototype,
                g = y[It] || y["@@iterator"] || n && y[n],
                m = g || d(n),
                x = n ? v ? d("entries") : m : void 0,
                E = "Array" == e && y.entries || g;
            if (E && (f = Ht(E.call(new t))) !== Object.prototype && f.next && (Vt(f, p, !0), "function" != typeof f[It] && X(f, It, Xt)), v && g && g.name !== $t && (b = !0, m = function () {
                return g.call(this)
            }), (qt || b || !y[It]) && X(y, It, m), yt[e] = m, yt[p] = Xt, n)
                if (u = {
                    values: v ? m : d($t),
                    keys: o ? m : d("keys"),
                    entries: x
                }, s)
                    for (h in u) h in y || U(y, h, u[h]);
                else Z(Z.P + Z.F * (qt || b), e, u);
            return u
        },
        Gt = Yt(Array, "Array", function (t, e) {
            this._t = mt(t), this._i = 0, this._k = e
        }, function () {
            var t = this._t,
                e = this._k,
                i = this._i++;
            return !t || i >= t.length ? (this._t = void 0, bt(1)) : bt(0, "keys" == e ? i : "values" == e ? t[i] : [i, t[i]])
        }, "values");
    yt.Arguments = yt.Array, vt("keys"), vt("values"), vt("entries");
    for (var Ut = x("iterator"), Jt = x("toStringTag"), Kt = yt.Array, Qt = {
        CSSRuleList: !0,
        CSSStyleDeclaration: !1,
        CSSValueList: !1,
        ClientRectList: !1,
        DOMRectList: !1,
        DOMStringList: !1,
        DOMTokenList: !0,
        DataTransferItemList: !1,
        FileList: !1,
        HTMLAllCollection: !1,
        HTMLCollection: !1,
        HTMLFormElement: !1,
        HTMLSelectElement: !1,
        MediaList: !0,
        MimeTypeArray: !1,
        NamedNodeMap: !1,
        NodeList: !0,
        PaintRequestList: !1,
        Plugin: !1,
        PluginArray: !1,
        SVGLengthList: !1,
        SVGNumberList: !1,
        SVGPathSegList: !1,
        SVGPointList: !1,
        SVGStringList: !1,
        SVGTransformList: !1,
        SourceBufferList: !1,
        StyleSheetList: !0,
        TextTrackCueList: !1,
        TextTrackList: !1,
        TouchList: !1
    }, Zt = At(Qt), te = 0; te < Zt.length; te++) {
        var ee, ie = Zt[te],
            re = Qt[ie],
            ne = b[ie],
            oe = ne && ne.prototype;
        if (oe && (oe[Ut] || X(oe, Ut, Kt), oe[Jt] || X(oe, Jt, ie), yt[ie] = Kt, re))
            for (ee in Gt) oe[ee] || U(oe, ee, Gt[ee], !0)
    }
    var se = t(!0);
    Yt(String, "String", function (t) {
        this._t = String(t), this._i = 0
    }, function () {
        var t, e = this._t,
            i = this._i;
        return i >= e.length ? {
            value: void 0,
            done: !0
        } : (t = se(e, i), this._i += t.length, {
            value: t,
            done: !1
        })
    });
    var ae = function (e, t, i, r) {
        try {
            return r ? t(O(i)[0], i[1]) : t(i)
        } catch (t) {
            var n = e.return;
            throw void 0 !== n && O(n.call(e)), t
        }
    },
        le = x("iterator"),
        ce = Array.prototype,
        ue = function (t, e, i) {
            e in t ? q.f(t, e, $(0, i)) : t[e] = i
        },
        he = x("iterator"),
        fe = v.getIteratorMethod = function (t) {
            if (null != t) return t[he] || t["@@iterator"] || yt[_(t)]
        },
        de = x("iterator"),
        pe = !1;
    try {
        [7][de]().return = function () {
            pe = !0
        }
    } catch (t) { }

    function ve(t, e) {
        for (var i = 0; i < e.length; i++) {
            var r = e[i];
            r.enumerable = r.enumerable || !1, r.configurable = !0, "value" in r && (r.writable = !0), Object.defineProperty(t, r.key, r)
        }
    }

    function be(n) {
        for (var t = 1; t < arguments.length; t++) {
            var o = null != arguments[t] ? arguments[t] : {},
                e = Object.keys(o);
            "function" == typeof Object.getOwnPropertySymbols && (e = e.concat(Object.getOwnPropertySymbols(o).filter(function (t) {
                return Object.getOwnPropertyDescriptor(o, t).enumerable
            }))), e.forEach(function (t) {
                var e, i, r;
                e = n, r = o[i = t], i in e ? Object.defineProperty(e, i, {
                    value: r,
                    enumerable: !0,
                    configurable: !0,
                    writable: !0
                }) : e[i] = r
            })
        }
        return n
    }
    Z(Z.S + Z.F * ! function (t, e) {
        if (!e && !pe) return !1;
        var i = !1;
        try {
            var r = [7],
                n = r[de]();
            n.next = function () {
                return {
                    done: i = !0
                }
            }, r[de] = function () {
                return n
            }, t(r)
        } catch (t) { }
        return i
    }(function (t) { }), "Array", {
            from: function (t) {
                var e, i, r, n, o, s = d(t),
                    a = "function" == typeof this ? this : Array,
                    l = arguments.length,
                    c = 1 < l ? arguments[1] : void 0,
                    u = void 0 !== c,
                    h = 0,
                    f = fe(s);
                if (u && (c = J(c, 2 < l ? arguments[2] : void 0, 2)), null != f && (a != Array || (void 0 === (o = f) || yt.Array !== o && ce[le] !== o)))
                    for (n = f.call(s), i = new a; !(r = n.next()).done; h++) ue(i, h, u ? ae(n, c, [r.value, h], !0) : r.value);
                else
                    for (i = new a(e = k(s.length)); h < e; h++) ue(i, h, u ? c(s[h], h) : s[h]);
                return i.length = h, i
            }
        });
    var ye = c(function (t, e) {
        t.exports = function () {
            if ("undefined" == typeof document) return 0;
            var t, e = document.body,
                i = document.createElement("div"),
                r = i.style;
            return r.position = "absolute", r.top = r.left = "-9999px", r.width = r.height = "100px", r.overflow = "scroll", e.appendChild(i), t = i.offsetWidth - i.clientWidth, e.removeChild(i), t
        }
    }),
        ge = "Expected a function",
        me = NaN,
        xe = "[object Symbol]",
        Ee = /^\s+|\s+$/g,
        we = /^[-+]0x[0-9a-f]+$/i,
        _e = /^0b[01]+$/i,
        Oe = /^0o[0-7]+$/i,
        Se = parseInt,
        ke = "object" == typeof l && l && l.Object === Object && l,
        Ae = "object" == typeof self && self && self.Object === Object && self,
        Me = ke || Ae || Function("return this")(),
        Le = Object.prototype.toString,
        Te = Math.max,
        je = Math.min,
        Re = function () {
            return Me.Date.now()
        };

    function Ne(r, n, t) {
        var o, s, a, l, c, u, h = 0,
            f = !1,
            d = !1,
            e = !0;
        if ("function" != typeof r) throw new TypeError(ge);

        function p(t) {
            var e = o,
                i = s;
            return o = s = void 0, h = t, l = r.apply(i, e)
        }

        function v(t) {
            var e = t - u;
            return void 0 === u || n <= e || e < 0 || d && a <= t - h
        }

        function b() {
            var t, e, i = Re();
            if (v(i)) return y(i);
            c = setTimeout(b, (e = n - ((t = i) - u), d ? je(e, a - (t - h)) : e))
        }

        function y(t) {
            return c = void 0, e && o ? p(t) : (o = s = void 0, l)
        }

        function i() {
            var t, e = Re(),
                i = v(e);
            if (o = arguments, s = this, u = e, i) {
                if (void 0 === c) return h = t = u, c = setTimeout(b, n), f ? p(t) : l;
                if (d) return c = setTimeout(b, n), p(u)
            }
            return void 0 === c && (c = setTimeout(b, n)), l
        }
        return n = Ce(n) || 0, We(t) && (f = !!t.leading, a = (d = "maxWait" in t) ? Te(Ce(t.maxWait) || 0, n) : a, e = "trailing" in t ? !!t.trailing : e), i.cancel = function () {
            void 0 !== c && clearTimeout(c), o = u = s = c = void (h = 0)
        }, i.flush = function () {
            return void 0 === c ? l : y(Re())
        }, i
    }

    function We(t) {
        var e = typeof t;
        return !!t && ("object" == e || "function" == e)
    }

    function Ce(t) {
        if ("number" == typeof t) return t;
        if ("symbol" == typeof (e = t) || (i = e) && "object" == typeof i && Le.call(e) == xe) return me;
        var e, i;
        if (We(t)) {
            var r = "function" == typeof t.valueOf ? t.valueOf() : t;
            t = We(r) ? r + "" : r
        }
        if ("string" != typeof t) return 0 === t ? t : +t;
        t = t.replace(Ee, "");
        var n = _e.test(t);
        return n || Oe.test(t) ? Se(t.slice(2), n ? 2 : 8) : we.test(t) ? me : +t
    }
    var ze = function (t, e, i) {
        var r = !0,
            n = !0;
        if ("function" != typeof t) throw new TypeError(ge);
        return We(i) && (r = "leading" in i ? !!i.leading : r, n = "trailing" in i ? !!i.trailing : n), Ne(t, e, {
            leading: r,
            maxWait: e,
            trailing: n
        })
    },
        De = NaN,
        Ve = "[object Symbol]",
        Be = /^\s+|\s+$/g,
        Pe = /^[-+]0x[0-9a-f]+$/i,
        Fe = /^0b[01]+$/i,
        He = /^0o[0-7]+$/i,
        Ie = parseInt,
        qe = "object" == typeof l && l && l.Object === Object && l,
        $e = "object" == typeof self && self && self.Object === Object && self,
        Xe = qe || $e || Function("return this")(),
        Ye = Object.prototype.toString,
        Ge = Math.max,
        Ue = Math.min,
        Je = function () {
            return Xe.Date.now()
        };

    function Ke(t) {
        var e = typeof t;
        return !!t && ("object" == e || "function" == e)
    }

    function Qe(t) {
        if ("number" == typeof t) return t;
        if ("symbol" == typeof (e = t) || (i = e) && "object" == typeof i && Ye.call(e) == Ve) return De;
        var e, i;
        if (Ke(t)) {
            var r = "function" == typeof t.valueOf ? t.valueOf() : t;
            t = Ke(r) ? r + "" : r
        }
        if ("string" != typeof t) return 0 === t ? t : +t;
        t = t.replace(Be, "");
        var n = Fe.test(t);
        return n || He.test(t) ? Ie(t.slice(2), n ? 2 : 8) : Pe.test(t) ? De : +t
    }
    var Ze = function (r, n, t) {
        var o, s, a, l, c, u, h = 0,
            f = !1,
            d = !1,
            e = !0;
        if ("function" != typeof r) throw new TypeError("Expected a function");

        function p(t) {
            var e = o,
                i = s;
            return o = s = void 0, h = t, l = r.apply(i, e)
        }

        function v(t) {
            var e = t - u;
            return void 0 === u || n <= e || e < 0 || d && a <= t - h
        }

        function b() {
            var t, e, i = Je();
            if (v(i)) return y(i);
            c = setTimeout(b, (e = n - ((t = i) - u), d ? Ue(e, a - (t - h)) : e))
        }

        function y(t) {
            return c = void 0, e && o ? p(t) : (o = s = void 0, l)
        }

        function i() {
            var t, e = Je(),
                i = v(e);
            if (o = arguments, s = this, u = e, i) {
                if (void 0 === c) return h = t = u, c = setTimeout(b, n), f ? p(t) : l;
                if (d) return c = setTimeout(b, n), p(u)
            }
            return void 0 === c && (c = setTimeout(b, n)), l
        }
        return n = Qe(n) || 0, Ke(t) && (f = !!t.leading, a = (d = "maxWait" in t) ? Ge(Qe(t.maxWait) || 0, n) : a, e = "trailing" in t ? !!t.trailing : e), i.cancel = function () {
            void 0 !== c && clearTimeout(c), o = u = s = c = void (h = 0)
        }, i.flush = function () {
            return void 0 === c ? l : y(Je())
        }, i
    },
        ti = "Expected a function",
        ei = "__lodash_hash_undefined__",
        ii = "[object Function]",
        ri = "[object GeneratorFunction]",
        ni = /^\[object .+?Constructor\]$/,
        oi = "object" == typeof l && l && l.Object === Object && l,
        si = "object" == typeof self && self && self.Object === Object && self,
        ai = oi || si || Function("return this")();
    var li, ci = Array.prototype,
        ui = Function.prototype,
        hi = Object.prototype,
        fi = ai["__core-js_shared__"],
        di = (li = /[^.]+$/.exec(fi && fi.keys && fi.keys.IE_PROTO || "")) ? "Symbol(src)_1." + li : "",
        pi = ui.toString,
        vi = hi.hasOwnProperty,
        bi = hi.toString,
        yi = RegExp("^" + pi.call(vi).replace(/[\\^$.*+?()[\]{}|]/g, "\\$&").replace(/hasOwnProperty|(function).*?(?=\\\()| for .+?(?=\\\])/g, "$1.*?") + "$"),
        gi = ci.splice,
        mi = Ai(ai, "Map"),
        xi = Ai(Object, "create");

    function Ei(t) {
        var e = -1,
            i = t ? t.length : 0;
        for (this.clear(); ++e < i;) {
            var r = t[e];
            this.set(r[0], r[1])
        }
    }

    function wi(t) {
        var e = -1,
            i = t ? t.length : 0;
        for (this.clear(); ++e < i;) {
            var r = t[e];
            this.set(r[0], r[1])
        }
    }

    function _i(t) {
        var e = -1,
            i = t ? t.length : 0;
        for (this.clear(); ++e < i;) {
            var r = t[e];
            this.set(r[0], r[1])
        }
    }

    function Oi(t, e) {
        for (var i, r, n = t.length; n--;)
            if ((i = t[n][0]) === (r = e) || i != i && r != r) return n;
        return -1
    }

    function Si(t) {
        return !(!Li(t) || (e = t, di && di in e)) && ((r = Li(i = t) ? bi.call(i) : "") == ii || r == ri || function (t) {
            var e = !1;
            if (null != t && "function" != typeof t.toString) try {
                e = !!(t + "")
            } catch (t) { }
            return e
        }(t) ? yi : ni).test(function (t) {
            if (null != t) {
                try {
                    return pi.call(t)
                } catch (t) { }
                try {
                    return t + ""
                } catch (t) { }
            }
            return ""
        }(t));
        var e, i, r
    }

    function ki(t, e) {
        var i, r, n = t.__data__;
        return ("string" == (r = typeof (i = e)) || "number" == r || "symbol" == r || "boolean" == r ? "__proto__" !== i : null === i) ? n["string" == typeof e ? "string" : "hash"] : n.map
    }

    function Ai(t, e) {
        var i, r, n = (r = e, null == (i = t) ? void 0 : i[r]);
        return Si(n) ? n : void 0
    }

    function Mi(n, o) {
        if ("function" != typeof n || o && "function" != typeof o) throw new TypeError(ti);
        var s = function () {
            var t = arguments,
                e = o ? o.apply(this, t) : t[0],
                i = s.cache;
            if (i.has(e)) return i.get(e);
            var r = n.apply(this, t);
            return s.cache = i.set(e, r), r
        };
        return s.cache = new (Mi.Cache || _i), s
    }

    function Li(t) {
        var e = typeof t;
        return !!t && ("object" == e || "function" == e)
    }
    Ei.prototype.clear = function () {
        this.__data__ = xi ? xi(null) : {}
    }, Ei.prototype.delete = function (t) {
        return this.has(t) && delete this.__data__[t]
    }, Ei.prototype.get = function (t) {
        var e = this.__data__;
        if (xi) {
            var i = e[t];
            return i === ei ? void 0 : i
        }
        return vi.call(e, t) ? e[t] : void 0
    }, Ei.prototype.has = function (t) {
        var e = this.__data__;
        return xi ? void 0 !== e[t] : vi.call(e, t)
    }, Ei.prototype.set = function (t, e) {
        return this.__data__[t] = xi && void 0 === e ? ei : e, this
    }, wi.prototype.clear = function () {
        this.__data__ = []
    }, wi.prototype.delete = function (t) {
        var e = this.__data__,
            i = Oi(e, t);
        return !(i < 0 || (i == e.length - 1 ? e.pop() : gi.call(e, i, 1), 0))
    }, wi.prototype.get = function (t) {
        var e = this.__data__,
            i = Oi(e, t);
        return i < 0 ? void 0 : e[i][1]
    }, wi.prototype.has = function (t) {
        return -1 < Oi(this.__data__, t)
    }, wi.prototype.set = function (t, e) {
        var i = this.__data__,
            r = Oi(i, t);
        return r < 0 ? i.push([t, e]) : i[r][1] = e, this
    }, _i.prototype.clear = function () {
        this.__data__ = {
            hash: new Ei,
            map: new (mi || wi),
            string: new Ei
        }
    }, _i.prototype.delete = function (t) {
        return ki(this, t).delete(t)
    }, _i.prototype.get = function (t) {
        return ki(this, t).get(t)
    }, _i.prototype.has = function (t) {
        return ki(this, t).has(t)
    }, _i.prototype.set = function (t, e) {
        return ki(this, t).set(t, e), this
    }, Mi.Cache = _i;
    var Ti = Mi,
        ji = function () {
            if ("undefined" != typeof Map) return Map;

            function r(t, i) {
                var r = -1;
                return t.some(function (t, e) {
                    return t[0] === i && (r = e, !0)
                }), r
            }
            return function () {
                function t() {
                    this.__entries__ = []
                }
                return Object.defineProperty(t.prototype, "size", {
                    get: function () {
                        return this.__entries__.length
                    },
                    enumerable: !0,
                    configurable: !0
                }), t.prototype.get = function (t) {
                    var e = r(this.__entries__, t),
                        i = this.__entries__[e];
                    return i && i[1]
                }, t.prototype.set = function (t, e) {
                    var i = r(this.__entries__, t);
                    ~i ? this.__entries__[i][1] = e : this.__entries__.push([t, e])
                }, t.prototype.delete = function (t) {
                    var e = this.__entries__,
                        i = r(e, t);
                    ~i && e.splice(i, 1)
                }, t.prototype.has = function (t) {
                    return !!~r(this.__entries__, t)
                }, t.prototype.clear = function () {
                    this.__entries__.splice(0)
                }, t.prototype.forEach = function (t, e) {
                    void 0 === e && (e = null);
                    for (var i = 0, r = this.__entries__; i < r.length; i++) {
                        var n = r[i];
                        t.call(e, n[1], n[0])
                    }
                }, t
            }()
        }(),
        Ri = "undefined" != typeof window && "undefined" != typeof document && window.document === document,
        Ni = "undefined" != typeof global && global.Math === Math ? global : "undefined" != typeof self && self.Math === Math ? self : "undefined" != typeof window && window.Math === Math ? window : Function("return this")(),
        Wi = "function" == typeof requestAnimationFrame ? requestAnimationFrame.bind(Ni) : function (t) {
            return setTimeout(function () {
                return t(Date.now())
            }, 1e3 / 60)
        },
        Ci = 2;
    var zi = ["top", "right", "bottom", "left", "width", "height", "size", "weight"],
        Di = "undefined" != typeof MutationObserver,
        Vi = function () {
            function t() {
                this.connected_ = !1, this.mutationEventsAdded_ = !1, this.mutationsObserver_ = null, this.observers_ = [], this.onTransitionEnd_ = this.onTransitionEnd_.bind(this), this.refresh = function (t, e) {
                    var i = !1,
                        r = !1,
                        n = 0;

                    function o() {
                        i && (i = !1, t()), r && a()
                    }

                    function s() {
                        Wi(o)
                    }

                    function a() {
                        var t = Date.now();
                        if (i) {
                            if (t - n < Ci) return;
                            r = !0
                        } else r = !(i = !0), setTimeout(s, e);
                        n = t
                    }
                    return a
                }(this.refresh.bind(this), 20)
            }
            return t.prototype.addObserver = function (t) {
                ~this.observers_.indexOf(t) || this.observers_.push(t), this.connected_ || this.connect_()
            }, t.prototype.removeObserver = function (t) {
                var e = this.observers_,
                    i = e.indexOf(t);
                ~i && e.splice(i, 1), !e.length && this.connected_ && this.disconnect_()
            }, t.prototype.refresh = function () {
                this.updateObservers_() && this.refresh()
            }, t.prototype.updateObservers_ = function () {
                var t = this.observers_.filter(function (t) {
                    return t.gatherActive(), t.hasActive()
                });
                return t.forEach(function (t) {
                    return t.broadcastActive()
                }), 0 < t.length
            }, t.prototype.connect_ = function () {
                Ri && !this.connected_ && (document.addEventListener("transitionend", this.onTransitionEnd_), window.addEventListener("resize", this.refresh), Di ? (this.mutationsObserver_ = new MutationObserver(this.refresh), this.mutationsObserver_.observe(document, {
                    attributes: !0,
                    childList: !0,
                    characterData: !0,
                    subtree: !0
                })) : (document.addEventListener("DOMSubtreeModified", this.refresh), this.mutationEventsAdded_ = !0), this.connected_ = !0)
            }, t.prototype.disconnect_ = function () {
                Ri && this.connected_ && (document.removeEventListener("transitionend", this.onTransitionEnd_), window.removeEventListener("resize", this.refresh), this.mutationsObserver_ && this.mutationsObserver_.disconnect(), this.mutationEventsAdded_ && document.removeEventListener("DOMSubtreeModified", this.refresh), this.mutationsObserver_ = null, this.mutationEventsAdded_ = !1, this.connected_ = !1)
            }, t.prototype.onTransitionEnd_ = function (t) {
                var e = t.propertyName,
                    i = void 0 === e ? "" : e;
                zi.some(function (t) {
                    return !!~i.indexOf(t)
                }) && this.refresh()
            }, t.getInstance = function () {
                return this.instance_ || (this.instance_ = new t), this.instance_
            }, t.instance_ = null, t
        }(),
        Bi = function (t, e) {
            for (var i = 0, r = Object.keys(e); i < r.length; i++) {
                var n = r[i];
                Object.defineProperty(t, n, {
                    value: e[n],
                    enumerable: !1,
                    writable: !1,
                    configurable: !0
                })
            }
            return t
        },
        Pi = function (t) {
            return t && t.ownerDocument && t.ownerDocument.defaultView || Ni
        },
        Fi = Yi(0, 0, 0, 0);

    function Hi(t) {
        return parseFloat(t) || 0
    }

    function Ii(i) {
        for (var t = [], e = 1; e < arguments.length; e++) t[e - 1] = arguments[e];
        return t.reduce(function (t, e) {
            return t + Hi(i["border-" + e + "-width"])
        }, 0)
    }

    function qi(t) {
        var e = t.clientWidth,
            i = t.clientHeight;
        if (!e && !i) return Fi;
        var r, n = Pi(t).getComputedStyle(t),
            o = function (t) {
                for (var e = {}, i = 0, r = ["top", "right", "bottom", "left"]; i < r.length; i++) {
                    var n = r[i],
                        o = t["padding-" + n];
                    e[n] = Hi(o)
                }
                return e
            }(n),
            s = o.left + o.right,
            a = o.top + o.bottom,
            l = Hi(n.width),
            c = Hi(n.height);
        if ("border-box" === n.boxSizing && (Math.round(l + s) !== e && (l -= Ii(n, "left", "right") + s), Math.round(c + a) !== i && (c -= Ii(n, "top", "bottom") + a)), (r = t) !== Pi(r).document.documentElement) {
            var u = Math.round(l + s) - e,
                h = Math.round(c + a) - i;
            1 !== Math.abs(u) && (l -= u), 1 !== Math.abs(h) && (c -= h)
        }
        return Yi(o.left, o.top, l, c)
    }
    var $i = "undefined" != typeof SVGGraphicsElement ? function (t) {
        return t instanceof Pi(t).SVGGraphicsElement
    } : function (t) {
        return t instanceof Pi(t).SVGElement && "function" == typeof t.getBBox
    };

    function Xi(t) {
        return Ri ? $i(t) ? Yi(0, 0, (e = t.getBBox()).width, e.height) : qi(t) : Fi;
        var e
    }

    function Yi(t, e, i, r) {
        return {
            x: t,
            y: e,
            width: i,
            height: r
        }
    }
    var Gi = function () {
        function t(t) {
            this.broadcastWidth = 0, this.broadcastHeight = 0, this.contentRect_ = Yi(0, 0, 0, 0), this.target = t
        }
        return t.prototype.isActive = function () {
            var t = Xi(this.target);
            return (this.contentRect_ = t).width !== this.broadcastWidth || t.height !== this.broadcastHeight
        }, t.prototype.broadcastRect = function () {
            var t = this.contentRect_;
            return this.broadcastWidth = t.width, this.broadcastHeight = t.height, t
        }, t
    }(),
        Ui = function (t, e) {
            var i, r, n, o, s, a, l, c = (r = (i = e).x, n = i.y, o = i.width, s = i.height, a = "undefined" != typeof DOMRectReadOnly ? DOMRectReadOnly : Object, l = Object.create(a.prototype), Bi(l, {
                x: r,
                y: n,
                width: o,
                height: s,
                top: n,
                right: r + o,
                bottom: s + n,
                left: r
            }), l);
            Bi(this, {
                target: t,
                contentRect: c
            })
        },
        Ji = function () {
            function t(t, e, i) {
                if (this.activeObservations_ = [], this.observations_ = new ji, "function" != typeof t) throw new TypeError("The callback provided as parameter 1 is not a function.");
                this.callback_ = t, this.controller_ = e, this.callbackCtx_ = i
            }
            return t.prototype.observe = function (t) {
                if (!arguments.length) throw new TypeError("1 argument required, but only 0 present.");
                if ("undefined" != typeof Element && Element instanceof Object) {
                    if (!(t instanceof Pi(t).Element)) throw new TypeError('parameter 1 is not of type "Element".');
                    var e = this.observations_;
                    e.has(t) || (e.set(t, new Gi(t)), this.controller_.addObserver(this), this.controller_.refresh())
                }
            }, t.prototype.unobserve = function (t) {
                if (!arguments.length) throw new TypeError("1 argument required, but only 0 present.");
                if ("undefined" != typeof Element && Element instanceof Object) {
                    if (!(t instanceof Pi(t).Element)) throw new TypeError('parameter 1 is not of type "Element".');
                    var e = this.observations_;
                    e.has(t) && (e.delete(t), e.size || this.controller_.removeObserver(this))
                }
            }, t.prototype.disconnect = function () {
                this.clearActive(), this.observations_.clear(), this.controller_.removeObserver(this)
            }, t.prototype.gatherActive = function () {
                var e = this;
                this.clearActive(), this.observations_.forEach(function (t) {
                    t.isActive() && e.activeObservations_.push(t)
                })
            }, t.prototype.broadcastActive = function () {
                if (this.hasActive()) {
                    var t = this.callbackCtx_,
                        e = this.activeObservations_.map(function (t) {
                            return new Ui(t.target, t.broadcastRect())
                        });
                    this.callback_.call(t, e, t), this.clearActive()
                }
            }, t.prototype.clearActive = function () {
                this.activeObservations_.splice(0)
            }, t.prototype.hasActive = function () {
                return 0 < this.activeObservations_.length
            }, t
        }(),
        Ki = "undefined" != typeof WeakMap ? new WeakMap : new ji,
        Qi = function t(e) {
            if (!(this instanceof t)) throw new TypeError("Cannot call a class as a function.");
            if (!arguments.length) throw new TypeError("1 argument required, but only 0 present.");
            var i = Vi.getInstance(),
                r = new Ji(e, i, this);
            Ki.set(this, r)
        };
    ["observe", "unobserve", "disconnect"].forEach(function (e) {
        Qi.prototype[e] = function () {
            var t;
            return (t = Ki.get(this))[e].apply(t, arguments)
        }
    });
    var Zi = void 0 !== Ni.ResizeObserver ? Ni.ResizeObserver : Qi,
        tr = !("undefined" == typeof window || !window.document || !window.document.createElement),
        er = function () {
            function l(t, e) {
                var o = this;
                ! function (t, e) {
                    if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
                }(this, l), this.onScroll = function () {
                    o.scrollXTicking || (window.requestAnimationFrame(o.scrollX), o.scrollXTicking = !0), o.scrollYTicking || (window.requestAnimationFrame(o.scrollY), o.scrollYTicking = !0)
                }, this.scrollX = function () {
                    o.axis.x.isOverflowing && (o.showScrollbar("x"), o.positionScrollbar("x")), o.scrollXTicking = !1
                }, this.scrollY = function () {
                    o.axis.y.isOverflowing && (o.showScrollbar("y"), o.positionScrollbar("y")), o.scrollYTicking = !1
                }, this.onMouseEnter = function () {
                    o.showScrollbar("x"), o.showScrollbar("y")
                }, this.onMouseMove = function (t) {
                    o.mouseX = t.clientX, o.mouseY = t.clientY, (o.axis.x.isOverflowing || o.axis.x.forceVisible) && o.onMouseMoveForAxis("x"), (o.axis.y.isOverflowing || o.axis.y.forceVisible) && o.onMouseMoveForAxis("y")
                }, this.onMouseLeave = function () {
                    o.onMouseMove.cancel(), (o.axis.x.isOverflowing || o.axis.x.forceVisible) && o.onMouseLeaveForAxis("x"), (o.axis.y.isOverflowing || o.axis.y.forceVisible) && o.onMouseLeaveForAxis("y"), o.mouseX = -1, o.mouseY = -1
                }, this.onWindowResize = function () {
                    o.scrollbarWidth = ye(), o.hideNativeScrollbar()
                }, this.hideScrollbars = function () {
                    o.axis.x.track.rect = o.axis.x.track.el.getBoundingClientRect(), o.axis.y.track.rect = o.axis.y.track.el.getBoundingClientRect(), o.isWithinBounds(o.axis.y.track.rect) || (o.axis.y.scrollbar.el.classList.remove(o.classNames.visible), o.axis.y.isVisible = !1), o.isWithinBounds(o.axis.x.track.rect) || (o.axis.x.scrollbar.el.classList.remove(o.classNames.visible), o.axis.x.isVisible = !1)
                }, this.onPointerEvent = function (t) {
                    var e, i;
                    o.axis.x.scrollbar.rect = o.axis.x.scrollbar.el.getBoundingClientRect(), o.axis.y.scrollbar.rect = o.axis.y.scrollbar.el.getBoundingClientRect(), (o.axis.x.isOverflowing || o.axis.x.forceVisible) && (i = o.isWithinBounds(o.axis.x.scrollbar.rect)), (o.axis.y.isOverflowing || o.axis.y.forceVisible) && (e = o.isWithinBounds(o.axis.y.scrollbar.rect)), (e || i) && (t.preventDefault(), t.stopPropagation(), "mousedown" === t.type && (e && o.onDragStart(t, "y"), i && o.onDragStart(t, "x")))
                }, this.drag = function (t) {
                    var e = o.axis[o.draggedAxis].track,
                        i = e.rect[o.axis[o.draggedAxis].sizeAttr],
                        r = o.axis[o.draggedAxis].scrollbar;
                    t.preventDefault(), t.stopPropagation();
                    var n = (("y" === o.draggedAxis ? t.pageY : t.pageX) - e.rect[o.axis[o.draggedAxis].offsetAttr] - o.axis[o.draggedAxis].dragOffset) / e.rect[o.axis[o.draggedAxis].sizeAttr] * o.contentEl[o.axis[o.draggedAxis].scrollSizeAttr];
                    "x" === o.draggedAxis && (n = o.isRtl && l.getRtlHelpers().isRtlScrollbarInverted ? n - (i + r.size) : n, n = o.isRtl && l.getRtlHelpers().isRtlScrollingInverted ? -n : n), o.contentEl[o.axis[o.draggedAxis].scrollOffsetAttr] = n
                }, this.onEndDrag = function (t) {
                    t.preventDefault(), t.stopPropagation(), document.removeEventListener("mousemove", o.drag), document.removeEventListener("mouseup", o.onEndDrag)
                }, this.el = t, this.flashTimeout, this.contentEl, this.offsetEl, this.maskEl, this.globalObserver, this.mutationObserver, this.resizeObserver, this.scrollbarWidth, this.minScrollbarWidth = 20, this.options = be({}, l.defaultOptions, e), this.classNames = be({}, l.defaultOptions.classNames, this.options.classNames), this.isRtl, this.axis = {
                    x: {
                        scrollOffsetAttr: "scrollLeft",
                        sizeAttr: "width",
                        scrollSizeAttr: "scrollWidth",
                        offsetAttr: "left",
                        overflowAttr: "overflowX",
                        dragOffset: 0,
                        isOverflowing: !0,
                        isVisible: !1,
                        forceVisible: !1,
                        track: {},
                        scrollbar: {}
                    },
                    y: {
                        scrollOffsetAttr: "scrollTop",
                        sizeAttr: "height",
                        scrollSizeAttr: "scrollHeight",
                        offsetAttr: "top",
                        overflowAttr: "overflowY",
                        dragOffset: 0,
                        isOverflowing: !0,
                        isVisible: !1,
                        forceVisible: !1,
                        track: {},
                        scrollbar: {}
                    }
                }, this.recalculate = ze(this.recalculate.bind(this), 64), this.onMouseMove = ze(this.onMouseMove.bind(this), 64), this.hideScrollbars = Ze(this.hideScrollbars.bind(this), this.options.timeout), this.onWindowResize = Ze(this.onWindowResize.bind(this), 64, {
                    leading: !0
                }), l.getRtlHelpers = Ti(l.getRtlHelpers), this.getContentElement = this.getScrollElement, this.init()
            }
            var t, e, i;
            return t = l, i = [{
                key: "getRtlHelpers",
                value: function () {
                    var t = document.createElement("div");
                    t.innerHTML = '<div class="hs-dummy-scrollbar-size"><div style="height: 200%; width: 200%; margin: 10px 0;"></div></div>';
                    var e = t.firstElementChild;
                    document.body.appendChild(e);
                    var i = e.firstElementChild;
                    e.scrollLeft = 0;
                    var r = l.getOffset(e),
                        n = l.getOffset(i);
                    e.scrollLeft = 999;
                    var o = l.getOffset(i);
                    return {
                        isRtlScrollingInverted: r.left !== n.left && n.left - o.left != 0,
                        isRtlScrollbarInverted: r.left !== n.left
                    }
                }
            }, {
                key: "initHtmlApi",
                value: function () {
                    this.initDOMLoadedElements = this.initDOMLoadedElements.bind(this), "undefined" != typeof MutationObserver && (this.globalObserver = new MutationObserver(function (t) {
                        t.forEach(function (t) {
                            Array.from(t.addedNodes).forEach(function (t) {
                                1 === t.nodeType && (t.hasAttribute("data-simplebar") ? !t.SimpleBar && new l(t, l.getElOptions(t)) : Array.from(t.querySelectorAll("[data-simplebar]")).forEach(function (t) {
                                    !t.SimpleBar && new l(t, l.getElOptions(t))
                                }))
                            }), Array.from(t.removedNodes).forEach(function (t) {
                                1 === t.nodeType && (t.hasAttribute("data-simplebar") ? t.SimpleBar && t.SimpleBar.unMount() : Array.from(t.querySelectorAll("[data-simplebar]")).forEach(function (t) {
                                    t.SimpleBar && t.SimpleBar.unMount()
                                }))
                            })
                        })
                    }), this.globalObserver.observe(document, {
                        childList: !0,
                        subtree: !0
                    })), "complete" === document.readyState || "loading" !== document.readyState && !document.documentElement.doScroll ? window.setTimeout(this.initDOMLoadedElements) : (document.addEventListener("DOMContentLoaded", this.initDOMLoadedElements), window.addEventListener("load", this.initDOMLoadedElements))
                }
            }, {
                key: "getElOptions",
                value: function (t) {
                    return Array.from(t.attributes).reduce(function (t, e) {
                        var i = e.name.match(/data-simplebar-(.+)/);
                        if (i) {
                            var r = i[1].replace(/\W+(.)/g, function (t, e) {
                                return e.toUpperCase()
                            });
                            switch (e.value) {
                                case "true":
                                    t[r] = !0;
                                    break;
                                case "false":
                                    t[r] = !1;
                                    break;
                                case void 0:
                                    t[r] = !0;
                                    break;
                                default:
                                    t[r] = e.value
                            }
                        }
                        return t
                    }, {})
                }
            }, {
                key: "removeObserver",
                value: function () {
                    this.globalObserver.disconnect()
                }
            }, {
                key: "initDOMLoadedElements",
                value: function () {
                    document.removeEventListener("DOMContentLoaded", this.initDOMLoadedElements), window.removeEventListener("load", this.initDOMLoadedElements), Array.from(document.querySelectorAll("[data-simplebar]")).forEach(function (t) {
                        t.SimpleBar || new l(t, l.getElOptions(t))
                    })
                }
            }, {
                key: "getOffset",
                value: function (t) {
                    var e = t.getBoundingClientRect();
                    return {
                        top: e.top + (window.pageYOffset || document.documentElement.scrollTop),
                        left: e.left + (window.pageXOffset || document.documentElement.scrollLeft)
                    }
                }
            }], (e = [{
                key: "init",
                value: function () {
                    this.el.SimpleBar = this, tr && (this.initDOM(), this.scrollbarWidth = ye(), this.recalculate(), this.initListeners())
                }
            }, {
                key: "initDOM",
                value: function () {
                    var e = this;
                    if (Array.from(this.el.children).filter(function (t) {
                        return t.classList.contains(e.classNames.wrapper)
                    }).length) this.wrapperEl = this.el.querySelector(".".concat(this.classNames.wrapper)), this.contentEl = this.el.querySelector(".".concat(this.classNames.content)), this.offsetEl = this.el.querySelector(".".concat(this.classNames.offset)), this.maskEl = this.el.querySelector(".".concat(this.classNames.mask)), this.placeholderEl = this.el.querySelector(".".concat(this.classNames.placeholder)), this.heightAutoObserverWrapperEl = this.el.querySelector(".".concat(this.classNames.heightAutoObserverWrapperEl)), this.heightAutoObserverEl = this.el.querySelector(".".concat(this.classNames.heightAutoObserverEl)), this.axis.x.track.el = this.el.querySelector(".".concat(this.classNames.track, ".").concat(this.classNames.horizontal)), this.axis.y.track.el = this.el.querySelector(".".concat(this.classNames.track, ".").concat(this.classNames.vertical));
                    else {
                        for (this.wrapperEl = document.createElement("div"), this.contentEl = document.createElement("div"), this.offsetEl = document.createElement("div"), this.maskEl = document.createElement("div"), this.placeholderEl = document.createElement("div"), this.heightAutoObserverWrapperEl = document.createElement("div"), this.heightAutoObserverEl = document.createElement("div"), this.wrapperEl.classList.add(this.classNames.wrapper), this.contentEl.classList.add(this.classNames.content), this.offsetEl.classList.add(this.classNames.offset), this.maskEl.classList.add(this.classNames.mask), this.placeholderEl.classList.add(this.classNames.placeholder), this.heightAutoObserverWrapperEl.classList.add(this.classNames.heightAutoObserverWrapperEl), this.heightAutoObserverEl.classList.add(this.classNames.heightAutoObserverEl); this.el.firstChild;) this.contentEl.appendChild(this.el.firstChild);
                        this.offsetEl.appendChild(this.contentEl), this.maskEl.appendChild(this.offsetEl), this.heightAutoObserverWrapperEl.appendChild(this.heightAutoObserverEl), this.wrapperEl.appendChild(this.heightAutoObserverWrapperEl), this.wrapperEl.appendChild(this.maskEl), this.wrapperEl.appendChild(this.placeholderEl), this.el.appendChild(this.wrapperEl)
                    }
                    if (!this.axis.x.track.el || !this.axis.y.track.el) {
                        var t = document.createElement("div"),
                            i = document.createElement("div");
                        t.classList.add(this.classNames.track), i.classList.add(this.classNames.scrollbar), this.options.autoHide || i.classList.add(this.classNames.visible), t.appendChild(i), this.axis.x.track.el = t.cloneNode(!0), this.axis.x.track.el.classList.add(this.classNames.horizontal), this.axis.y.track.el = t.cloneNode(!0), this.axis.y.track.el.classList.add(this.classNames.vertical), this.el.appendChild(this.axis.x.track.el), this.el.appendChild(this.axis.y.track.el)
                    }
                    this.axis.x.scrollbar.el = this.axis.x.track.el.querySelector(".".concat(this.classNames.scrollbar)), this.axis.y.scrollbar.el = this.axis.y.track.el.querySelector(".".concat(this.classNames.scrollbar)), this.el.setAttribute("data-simplebar", "init")
                }
            }, {
                key: "initListeners",
                value: function () {
                    var e = this;
                    this.options.autoHide && this.el.addEventListener("mouseenter", this.onMouseEnter), ["mousedown", "click", "dblclick", "touchstart", "touchend", "touchmove"].forEach(function (t) {
                        e.el.addEventListener(t, e.onPointerEvent, !0)
                    }), this.el.addEventListener("mousemove", this.onMouseMove), this.el.addEventListener("mouseleave", this.onMouseLeave), this.contentEl.addEventListener("scroll", this.onScroll), window.addEventListener("resize", this.onWindowResize), "undefined" != typeof MutationObserver && (this.mutationObserver = new MutationObserver(function (t) {
                        t.forEach(function (t) {
                            (t.target === e.el || !e.isChildNode(t.target) || t.addedNodes.length || t.removedNodes.length) && e.recalculate()
                        })
                    }), this.mutationObserver.observe(this.el, {
                        attributes: !0,
                        childList: !0,
                        characterData: !0,
                        subtree: !0
                    })), this.resizeObserver = new Zi(this.recalculate), this.resizeObserver.observe(this.el)
                }
            }, {
                key: "recalculate",
                value: function () {
                    var t = this.heightAutoObserverEl.offsetHeight <= 1;
                    this.elStyles = window.getComputedStyle(this.el), this.isRtl = "rtl" === this.elStyles.direction, this.contentEl.style.padding = "".concat(this.elStyles.paddingTop, " ").concat(this.elStyles.paddingRight, " ").concat(this.elStyles.paddingBottom, " ").concat(this.elStyles.paddingLeft), this.contentEl.style.height = t ? "auto" : "100%", this.placeholderEl.style.width = "".concat(this.contentEl.scrollWidth, "px"), this.placeholderEl.style.height = "".concat(this.contentEl.scrollHeight, "px"), this.wrapperEl.style.margin = "-".concat(this.elStyles.paddingTop, " -").concat(this.elStyles.paddingRight, " -").concat(this.elStyles.paddingBottom, " -").concat(this.elStyles.paddingLeft), this.axis.x.track.rect = this.axis.x.track.el.getBoundingClientRect(), this.axis.y.track.rect = this.axis.y.track.el.getBoundingClientRect(), this.axis.x.isOverflowing = (this.scrollbarWidth ? this.contentEl.scrollWidth : this.contentEl.scrollWidth - this.minScrollbarWidth) > Math.ceil(this.axis.x.track.rect.width), this.axis.y.isOverflowing = (this.scrollbarWidth ? this.contentEl.scrollHeight : this.contentEl.scrollHeight - this.minScrollbarWidth) > Math.ceil(this.axis.y.track.rect.height), this.axis.x.isOverflowing = "hidden" !== this.elStyles.overflowX && this.axis.x.isOverflowing, this.axis.y.isOverflowing = "hidden" !== this.elStyles.overflowY && this.axis.y.isOverflowing, this.axis.x.forceVisible = "x" === this.options.forceVisible || !0 === this.options.forceVisible, this.axis.y.forceVisible = "y" === this.options.forceVisible || !0 === this.options.forceVisible, this.axis.x.scrollbar.size = this.getScrollbarSize("x"), this.axis.y.scrollbar.size = this.getScrollbarSize("y"), this.axis.x.scrollbar.el.style.width = "".concat(this.axis.x.scrollbar.size, "px"), this.axis.y.scrollbar.el.style.height = "".concat(this.axis.y.scrollbar.size, "px"), this.positionScrollbar("x"), this.positionScrollbar("y"), this.toggleTrackVisibility("x"), this.toggleTrackVisibility("y"), this.hideNativeScrollbar()
                }
            }, {
                key: "getScrollbarSize",
                value: function () {
                    var t, e = 0 < arguments.length && void 0 !== arguments[0] ? arguments[0] : "y",
                        i = this.scrollbarWidth ? this.contentEl[this.axis[e].scrollSizeAttr] : this.contentEl[this.axis[e].scrollSizeAttr] - this.minScrollbarWidth,
                        r = this.axis[e].track.rect[this.axis[e].sizeAttr];
                    if (this.axis[e].isOverflowing) {
                        var n = r / i;
                        return t = Math.max(~~(n * r), this.options.scrollbarMinSize), this.options.scrollbarMaxSize && (t = Math.min(t, this.options.scrollbarMaxSize)), t
                    }
                }
            }, {
                key: "positionScrollbar",
                value: function () {
                    var t = 0 < arguments.length && void 0 !== arguments[0] ? arguments[0] : "y",
                        e = this.contentEl[this.axis[t].scrollSizeAttr],
                        i = this.axis[t].track.rect[this.axis[t].sizeAttr],
                        r = parseInt(this.elStyles[this.axis[t].sizeAttr], 10),
                        n = this.axis[t].scrollbar,
                        o = this.contentEl[this.axis[t].scrollOffsetAttr],
                        s = (o = "x" === t && this.isRtl && l.getRtlHelpers().isRtlScrollingInverted ? -o : o) / (e - r),
                        a = ~~((i - n.size) * s);
                    a = "x" === t && this.isRtl && l.getRtlHelpers().isRtlScrollbarInverted ? a + (i - n.size) : a, n.el.style.transform = "x" === t ? "translate3d(".concat(a, "px, 0, 0)") : "translate3d(0, ".concat(a, "px, 0)")
                }
            }, {
                key: "toggleTrackVisibility",
                value: function () {
                    var t = 0 < arguments.length && void 0 !== arguments[0] ? arguments[0] : "y",
                        e = this.axis[t].track.el,
                        i = this.axis[t].scrollbar.el;
                    this.axis[t].isOverflowing || this.axis[t].forceVisible ? (e.style.visibility = "visible", this.contentEl.style[this.axis[t].overflowAttr] = "scroll") : (e.style.visibility = "hidden", this.contentEl.style[this.axis[t].overflowAttr] = "hidden"), this.axis[t].isOverflowing ? i.style.visibility = "visible" : i.style.visibility = "hidden"
                }
            }, {
                key: "hideNativeScrollbar",
                value: function () {
                    if (this.offsetEl.style[this.isRtl ? "left" : "right"] = this.axis.y.isOverflowing || this.axis.y.forceVisible ? "-".concat(this.scrollbarWidth || this.minScrollbarWidth, "px") : 0, this.offsetEl.style.bottom = this.axis.x.isOverflowing || this.axis.x.forceVisible ? "-".concat(this.scrollbarWidth || this.minScrollbarWidth, "px") : 0, !this.scrollbarWidth) {
                        var t = [this.isRtl ? "paddingLeft" : "paddingRight"];
                        this.contentEl.style[t] = this.axis.y.isOverflowing || this.axis.y.forceVisible ? "calc(".concat(this.elStyles[t], " + ").concat(this.minScrollbarWidth, "px)") : this.elStyles[t], this.contentEl.style.paddingBottom = this.axis.x.isOverflowing || this.axis.x.forceVisible ? "calc(".concat(this.elStyles.paddingBottom, " + ").concat(this.minScrollbarWidth, "px)") : this.elStyles.paddingBottom
                    }
                }
            }, {
                key: "onMouseMoveForAxis",
                value: function () {
                    var t = 0 < arguments.length && void 0 !== arguments[0] ? arguments[0] : "y";
                    this.axis[t].track.rect = this.axis[t].track.el.getBoundingClientRect(), this.axis[t].scrollbar.rect = this.axis[t].scrollbar.el.getBoundingClientRect(), this.isWithinBounds(this.axis[t].scrollbar.rect) ? this.axis[t].scrollbar.el.classList.add(this.classNames.hover) : this.axis[t].scrollbar.el.classList.remove(this.classNames.hover), this.isWithinBounds(this.axis[t].track.rect) ? (this.showScrollbar(t), this.axis[t].track.el.classList.add(this.classNames.hover)) : this.axis[t].track.el.classList.remove(this.classNames.hover)
                }
            }, {
                key: "onMouseLeaveForAxis",
                value: function () {
                    var t = 0 < arguments.length && void 0 !== arguments[0] ? arguments[0] : "y";
                    this.axis[t].track.el.classList.remove(this.classNames.hover), this.axis[t].scrollbar.el.classList.remove(this.classNames.hover)
                }
            }, {
                key: "showScrollbar",
                value: function () {
                    var t = 0 < arguments.length && void 0 !== arguments[0] ? arguments[0] : "y",
                        e = this.axis[t].scrollbar.el;
                    this.axis[t].isVisible || (e.classList.add(this.classNames.visible), this.axis[t].isVisible = !0), this.options.autoHide && this.hideScrollbars()
                }
            }, {
                key: "onDragStart",
                value: function (t) {
                    var e = 1 < arguments.length && void 0 !== arguments[1] ? arguments[1] : "y",
                        i = this.axis[e].scrollbar.el,
                        r = "y" === e ? t.pageY : t.pageX;
                    this.axis[e].dragOffset = r - i.getBoundingClientRect()[this.axis[e].offsetAttr], this.draggedAxis = e, document.addEventListener("mousemove", this.drag), document.addEventListener("mouseup", this.onEndDrag)
                }
            }, {
                key: "getScrollElement",
                value: function () {
                    return this.contentEl
                }
            }, {
                key: "removeListeners",
                value: function () {
                    var e = this;
                    this.options.autoHide && this.el.removeEventListener("mouseenter", this.onMouseEnter), ["mousedown", "click", "dblclick", "touchstart", "touchend", "touchmove"].forEach(function (t) {
                        e.el.removeEventListener(t, e.onPointerEvent)
                    }), this.el.removeEventListener("mousemove", this.onMouseMove), this.el.removeEventListener("mouseleave", this.onMouseLeave), this.contentEl.removeEventListener("scroll", this.onScroll), window.removeEventListener("resize", this.onWindowResize), this.mutationObserver && this.mutationObserver.disconnect(), this.resizeObserver.disconnect(), this.recalculate.cancel(), this.onMouseMove.cancel(), this.hideScrollbars.cancel(), this.onWindowResize.cancel()
                }
            }, {
                key: "unMount",
                value: function () {
                    this.removeListeners(), this.el.SimpleBar = null
                }
            }, {
                key: "isChildNode",
                value: function (t) {
                    return null !== t && (t === this.el || this.isChildNode(t.parentNode))
                }
            }, {
                key: "isWithinBounds",
                value: function (t) {
                    return this.mouseX >= t.left && this.mouseX <= t.left + t.width && this.mouseY >= t.top && this.mouseY <= t.top + t.height
                }
            }]) && ve(t.prototype, e), i && ve(t, i), l
        }();
    return er.defaultOptions = {
        autoHide: !0,
        forceVisible: !1,
        classNames: {
            content: "simplebar-content",
            offset: "simplebar-offset",
            mask: "simplebar-mask",
            wrapper: "simplebar-wrapper",
            placeholder: "simplebar-placeholder",
            scrollbar: "simplebar-scrollbar",
            track: "simplebar-track",
            heightAutoObserverWrapperEl: "simplebar-height-auto-observer-wrapper",
            heightAutoObserverEl: "simplebar-height-auto-observer",
            visible: "simplebar-visible",
            horizontal: "simplebar-horizontal",
            vertical: "simplebar-vertical",
            hover: "simplebar-hover"
        },
        scrollbarMinSize: 25,
        scrollbarMaxSize: 0,
        timeout: 1e3
    }, tr && er.initHtmlApi(), er
});
(function (i) {
    "use strict";
    "function" == typeof define && define.amd ? define(["jquery"], i) : "undefined" != typeof exports ? module.exports = i(require("jquery")) : i(jQuery)
})(function (i) {
    "use strict";
    var e = window.Slick || {};
    e = function () {
        function e(e, o) {
            var s, n = this;
            n.defaults = {
                accessibility: !0,
                adaptiveHeight: !1,
                appendArrows: i(e),
                appendDots: i(e),
                arrows: !0,
                asNavFor: null,
                prevArrow: '<button class="slick-prev" aria-label="Previous" type="button">Previous</button>',
                nextArrow: '<button class="slick-next" aria-label="Next" type="button">Next</button>',
                autoplay: !1,
                autoplaySpeed: 3e3,
                centerMode: !1,
                centerPadding: "50px",
                cssEase: "ease",
                customPaging: function (e, t) {
                    return i('<button type="button" />').text(t + 1)
                },
                dots: !1,
                dotsClass: "slick-dots",
                draggable: !0,
                easing: "linear",
                edgeFriction: .35,
                fade: !1,
                focusOnSelect: !1,
                focusOnChange: !1,
                infinite: !0,
                initialSlide: 0,
                lazyLoad: "ondemand",
                mobileFirst: !1,
                pauseOnHover: !0,
                pauseOnFocus: !0,
                pauseOnDotsHover: !1,
                respondTo: "window",
                responsive: null,
                rows: 1,
                rtl: !1,
                slide: "",
                slidesPerRow: 1,
                slidesToShow: 1,
                slidesToScroll: 1,
                speed: 500,
                swipe: !0,
                swipeToSlide: !1,
                touchMove: !0,
                touchThreshold: 5,
                useCSS: !0,
                useTransform: !0,
                variableWidth: !1,
                vertical: !1,
                verticalSwiping: !1,
                waitForAnimate: !0,
                zIndex: 1e3
            }, n.initials = {
                animating: !1,
                dragging: !1,
                autoPlayTimer: null,
                currentDirection: 0,
                currentLeft: null,
                currentSlide: 0,
                direction: 1,
                $dots: null,
                listWidth: null,
                listHeight: null,
                loadIndex: 0,
                $nextArrow: null,
                $prevArrow: null,
                scrolling: !1,
                slideCount: null,
                slideWidth: null,
                $slideTrack: null,
                $slides: null,
                sliding: !1,
                slideOffset: 0,
                swipeLeft: null,
                swiping: !1,
                $list: null,
                touchObject: {},
                transformsEnabled: !1,
                unslicked: !1
            }, i.extend(n, n.initials), n.activeBreakpoint = null, n.animType = null, n.animProp = null, n.breakpoints = [], n.breakpointSettings = [], n.cssTransitions = !1, n.focussed = !1, n.interrupted = !1, n.hidden = "hidden", n.paused = !0, n.positionProp = null, n.respondTo = null, n.rowCount = 1, n.shouldClick = !0, n.$slider = i(e), n.$slidesCache = null, n.transformType = null, n.transitionType = null, n.visibilityChange = "visibilitychange", n.windowWidth = 0, n.windowTimer = null, s = i(e).data("slick") || {}, n.options = i.extend({}, n.defaults, o, s), n.currentSlide = n.options.initialSlide, n.originalSettings = n.options, "undefined" != typeof document.mozHidden ? (n.hidden = "mozHidden", n.visibilityChange = "mozvisibilitychange") : "undefined" != typeof document.webkitHidden && (n.hidden = "webkitHidden", n.visibilityChange = "webkitvisibilitychange"), n.autoPlay = i.proxy(n.autoPlay, n), n.autoPlayClear = i.proxy(n.autoPlayClear, n), n.autoPlayIterator = i.proxy(n.autoPlayIterator, n), n.changeSlide = i.proxy(n.changeSlide, n), n.clickHandler = i.proxy(n.clickHandler, n), n.selectHandler = i.proxy(n.selectHandler, n), n.setPosition = i.proxy(n.setPosition, n), n.swipeHandler = i.proxy(n.swipeHandler, n), n.dragHandler = i.proxy(n.dragHandler, n), n.keyHandler = i.proxy(n.keyHandler, n), n.instanceUid = t++ , n.htmlExpr = /^(?:\s*(<[\w\W]+>)[^>]*)$/, n.registerBreakpoints(), n.init(!0)
        }
        var t = 0;
        return e
    }(), e.prototype.activateADA = function () {
        var i = this;
        i.$slideTrack.find(".slick-active").attr({
            "aria-hidden": "false"
        }).find("a, input, button, select").attr({
            tabindex: "0"
        })
    }, e.prototype.addSlide = e.prototype.slickAdd = function (e, t, o) {
        var s = this;
        if ("boolean" == typeof t) o = t, t = null;
        else if (t < 0 || t >= s.slideCount) return !1;
        s.unload(), "number" == typeof t ? 0 === t && 0 === s.$slides.length ? i(e).appendTo(s.$slideTrack) : o ? i(e).insertBefore(s.$slides.eq(t)) : i(e).insertAfter(s.$slides.eq(t)) : o === !0 ? i(e).prependTo(s.$slideTrack) : i(e).appendTo(s.$slideTrack), s.$slides = s.$slideTrack.children(this.options.slide), s.$slideTrack.children(this.options.slide).detach(), s.$slideTrack.append(s.$slides), s.$slides.each(function (e, t) {
            i(t).attr("data-slick-index", e)
        }), s.$slidesCache = s.$slides, s.reinit()
    }, e.prototype.animateHeight = function () {
        var i = this;
        if (1 === i.options.slidesToShow && i.options.adaptiveHeight === !0 && i.options.vertical === !1) {
            var e = i.$slides.eq(i.currentSlide).outerHeight(!0);
            i.$list.animate({
                height: e
            }, i.options.speed)
        }
    }, e.prototype.animateSlide = function (e, t) {
        var o = {},
            s = this;
        s.animateHeight(), s.options.rtl === !0 && s.options.vertical === !1 && (e = -e), s.transformsEnabled === !1 ? s.options.vertical === !1 ? s.$slideTrack.animate({
            left: e
        }, s.options.speed, s.options.easing, t) : s.$slideTrack.animate({
            top: e
        }, s.options.speed, s.options.easing, t) : s.cssTransitions === !1 ? (s.options.rtl === !0 && (s.currentLeft = -s.currentLeft), i({
            animStart: s.currentLeft
        }).animate({
            animStart: e
        }, {
                duration: s.options.speed,
                easing: s.options.easing,
                step: function (i) {
                    i = Math.ceil(i), s.options.vertical === !1 ? (o[s.animType] = "translate(" + i + "px, 0px)", s.$slideTrack.css(o)) : (o[s.animType] = "translate(0px," + i + "px)", s.$slideTrack.css(o))
                },
                complete: function () {
                    t && t.call()
                }
            })) : (s.applyTransition(), e = Math.ceil(e), s.options.vertical === !1 ? o[s.animType] = "translate3d(" + e + "px, 0px, 0px)" : o[s.animType] = "translate3d(0px," + e + "px, 0px)", s.$slideTrack.css(o), t && setTimeout(function () {
                s.disableTransition(), t.call()
            }, s.options.speed))
    }, e.prototype.getNavTarget = function () {
        var e = this,
            t = e.options.asNavFor;
        return t && null !== t && (t = i(t).not(e.$slider)), t
    }, e.prototype.asNavFor = function (e) {
        var t = this,
            o = t.getNavTarget();
        null !== o && "object" == typeof o && o.each(function () {
            var t = i(this).slick("getSlick");
            t.unslicked || t.slideHandler(e, !0)
        })
    }, e.prototype.applyTransition = function (i) {
        var e = this,
            t = {};
        e.options.fade === !1 ? t[e.transitionType] = e.transformType + " " + e.options.speed + "ms " + e.options.cssEase : t[e.transitionType] = "opacity " + e.options.speed + "ms " + e.options.cssEase, e.options.fade === !1 ? e.$slideTrack.css(t) : e.$slides.eq(i).css(t)
    }, e.prototype.autoPlay = function () {
        var i = this;
        i.autoPlayClear(), i.slideCount > i.options.slidesToShow && (i.autoPlayTimer = setInterval(i.autoPlayIterator, i.options.autoplaySpeed))
    }, e.prototype.autoPlayClear = function () {
        var i = this;
        i.autoPlayTimer && clearInterval(i.autoPlayTimer)
    }, e.prototype.autoPlayIterator = function () {
        var i = this,
            e = i.currentSlide + i.options.slidesToScroll;
        i.paused || i.interrupted || i.focussed || (i.options.infinite === !1 && (1 === i.direction && i.currentSlide + 1 === i.slideCount - 1 ? i.direction = 0 : 0 === i.direction && (e = i.currentSlide - i.options.slidesToScroll, i.currentSlide - 1 === 0 && (i.direction = 1))), i.slideHandler(e))
    }, e.prototype.buildArrows = function () {
        var e = this;
        e.options.arrows === !0 && (e.$prevArrow = i(e.options.prevArrow).addClass("slick-arrow"), e.$nextArrow = i(e.options.nextArrow).addClass("slick-arrow"), e.slideCount > e.options.slidesToShow ? (e.$prevArrow.removeClass("slick-hidden").removeAttr("aria-hidden tabindex"), e.$nextArrow.removeClass("slick-hidden").removeAttr("aria-hidden tabindex"), e.htmlExpr.test(e.options.prevArrow) && e.$prevArrow.prependTo(e.options.appendArrows), e.htmlExpr.test(e.options.nextArrow) && e.$nextArrow.appendTo(e.options.appendArrows), e.options.infinite !== !0 && e.$prevArrow.addClass("slick-disabled").attr("aria-disabled", "true")) : e.$prevArrow.add(e.$nextArrow).addClass("slick-hidden").attr({
            "aria-disabled": "true",
            tabindex: "-1"
        }))
    }, e.prototype.buildDots = function () {
        var e, t, o = this;
        if (o.options.dots === !0 && o.slideCount > o.options.slidesToShow) {
            for (o.$slider.addClass("slick-dotted"), t = i("<ul />").addClass(o.options.dotsClass), e = 0; e <= o.getDotCount(); e += 1) t.append(i("<li />").append(o.options.customPaging.call(this, o, e)));
            o.$dots = t.appendTo(o.options.appendDots), o.$dots.find("li").first().addClass("slick-active")
        }
    }, e.prototype.buildOut = function () {
        var e = this;
        e.$slides = e.$slider.children(e.options.slide + ":not(.slick-cloned)").addClass("slick-slide"), e.slideCount = e.$slides.length, e.$slides.each(function (e, t) {
            i(t).attr("data-slick-index", e).data("originalStyling", i(t).attr("style") || "")
        }), e.$slider.addClass("slick-slider"), e.$slideTrack = 0 === e.slideCount ? i('<div class="slick-track"/>').appendTo(e.$slider) : e.$slides.wrapAll('<div class="slick-track"/>').parent(), e.$list = e.$slideTrack.wrap('<div class="slick-list"/>').parent(), e.$slideTrack.css("opacity", 0), e.options.centerMode !== !0 && e.options.swipeToSlide !== !0 || (e.options.slidesToScroll = 1), i("img[data-lazy]", e.$slider).not("[src]").addClass("slick-loading"), e.setupInfinite(), e.buildArrows(), e.buildDots(), e.updateDots(), e.setSlideClasses("number" == typeof e.currentSlide ? e.currentSlide : 0), e.options.draggable === !0 && e.$list.addClass("draggable")
    }, e.prototype.buildRows = function () {
        var i, e, t, o, s, n, r, l = this;
        if (o = document.createDocumentFragment(), n = l.$slider.children(), l.options.rows > 0) {
            for (r = l.options.slidesPerRow * l.options.rows, s = Math.ceil(n.length / r), i = 0; i < s; i++) {
                var d = document.createElement("div");
                for (e = 0; e < l.options.rows; e++) {
                    var a = document.createElement("div");
                    for (t = 0; t < l.options.slidesPerRow; t++) {
                        var c = i * r + (e * l.options.slidesPerRow + t);
                        n.get(c) && a.appendChild(n.get(c))
                    }
                    d.appendChild(a)
                }
                o.appendChild(d)
            }
            l.$slider.empty().append(o), l.$slider.children().children().children().css({
                width: 100 / l.options.slidesPerRow + "%",
                display: "inline-block"
            })
        }
    }, e.prototype.checkResponsive = function (e, t) {
        var o, s, n, r = this,
            l = !1,
            d = r.$slider.width(),
            a = window.innerWidth || i(window).width();
        if ("window" === r.respondTo ? n = a : "slider" === r.respondTo ? n = d : "min" === r.respondTo && (n = Math.min(a, d)), r.options.responsive && r.options.responsive.length && null !== r.options.responsive) {
            s = null;
            for (o in r.breakpoints) r.breakpoints.hasOwnProperty(o) && (r.originalSettings.mobileFirst === !1 ? n < r.breakpoints[o] && (s = r.breakpoints[o]) : n > r.breakpoints[o] && (s = r.breakpoints[o]));
            null !== s ? null !== r.activeBreakpoint ? (s !== r.activeBreakpoint || t) && (r.activeBreakpoint = s, "unslick" === r.breakpointSettings[s] ? r.unslick(s) : (r.options = i.extend({}, r.originalSettings, r.breakpointSettings[s]), e === !0 && (r.currentSlide = r.options.initialSlide), r.refresh(e)), l = s) : (r.activeBreakpoint = s, "unslick" === r.breakpointSettings[s] ? r.unslick(s) : (r.options = i.extend({}, r.originalSettings, r.breakpointSettings[s]), e === !0 && (r.currentSlide = r.options.initialSlide), r.refresh(e)), l = s) : null !== r.activeBreakpoint && (r.activeBreakpoint = null, r.options = r.originalSettings, e === !0 && (r.currentSlide = r.options.initialSlide), r.refresh(e), l = s), e || l === !1 || r.$slider.trigger("breakpoint", [r, l])
        }
    }, e.prototype.changeSlide = function (e, t) {
        var o, s, n, r = this,
            l = i(e.currentTarget);
        switch (l.is("a") && e.preventDefault(), l.is("li") || (l = l.closest("li")), n = r.slideCount % r.options.slidesToScroll !== 0, o = n ? 0 : (r.slideCount - r.currentSlide) % r.options.slidesToScroll, e.data.message) {
            case "previous":
                s = 0 === o ? r.options.slidesToScroll : r.options.slidesToShow - o, r.slideCount > r.options.slidesToShow && r.slideHandler(r.currentSlide - s, !1, t);
                break;
            case "next":
                s = 0 === o ? r.options.slidesToScroll : o, r.slideCount > r.options.slidesToShow && r.slideHandler(r.currentSlide + s, !1, t);
                break;
            case "index":
                var d = 0 === e.data.index ? 0 : e.data.index || l.index() * r.options.slidesToScroll;
                r.slideHandler(r.checkNavigable(d), !1, t), l.children().trigger("focus");
                break;
            default:
                return
        }
    }, e.prototype.checkNavigable = function (i) {
        var e, t, o = this;
        if (e = o.getNavigableIndexes(), t = 0, i > e[e.length - 1]) i = e[e.length - 1];
        else
            for (var s in e) {
                if (i < e[s]) {
                    i = t;
                    break
                }
                t = e[s]
            }
        return i
    }, e.prototype.cleanUpEvents = function () {
        var e = this;
        e.options.dots && null !== e.$dots && (i("li", e.$dots).off("click.slick", e.changeSlide).off("mouseenter.slick", i.proxy(e.interrupt, e, !0)).off("mouseleave.slick", i.proxy(e.interrupt, e, !1)), e.options.accessibility === !0 && e.$dots.off("keydown.slick", e.keyHandler)), e.$slider.off("focus.slick blur.slick"), e.options.arrows === !0 && e.slideCount > e.options.slidesToShow && (e.$prevArrow && e.$prevArrow.off("click.slick", e.changeSlide), e.$nextArrow && e.$nextArrow.off("click.slick", e.changeSlide), e.options.accessibility === !0 && (e.$prevArrow && e.$prevArrow.off("keydown.slick", e.keyHandler), e.$nextArrow && e.$nextArrow.off("keydown.slick", e.keyHandler))), e.$list.off("touchstart.slick mousedown.slick", e.swipeHandler), e.$list.off("touchmove.slick mousemove.slick", e.swipeHandler), e.$list.off("touchend.slick mouseup.slick", e.swipeHandler), e.$list.off("touchcancel.slick mouseleave.slick", e.swipeHandler), e.$list.off("click.slick", e.clickHandler), i(document).off(e.visibilityChange, e.visibility), e.cleanUpSlideEvents(), e.options.accessibility === !0 && e.$list.off("keydown.slick", e.keyHandler), e.options.focusOnSelect === !0 && i(e.$slideTrack).children().off("click.slick", e.selectHandler), i(window).off("orientationchange.slick.slick-" + e.instanceUid, e.orientationChange), i(window).off("resize.slick.slick-" + e.instanceUid, e.resize), i("[draggable!=true]", e.$slideTrack).off("dragstart", e.preventDefault), i(window).off("load.slick.slick-" + e.instanceUid, e.setPosition)
    }, e.prototype.cleanUpSlideEvents = function () {
        var e = this;
        e.$list.off("mouseenter.slick", i.proxy(e.interrupt, e, !0)), e.$list.off("mouseleave.slick", i.proxy(e.interrupt, e, !1))
    }, e.prototype.cleanUpRows = function () {
        var i, e = this;
        e.options.rows > 0 && (i = e.$slides.children().children(), i.removeAttr("style"), e.$slider.empty().append(i))
    }, e.prototype.clickHandler = function (i) {
        var e = this;
        e.shouldClick === !1 && (i.stopImmediatePropagation(), i.stopPropagation(), i.preventDefault())
    }, e.prototype.destroy = function (e) {
        var t = this;
        t.autoPlayClear(), t.touchObject = {}, t.cleanUpEvents(), i(".slick-cloned", t.$slider).detach(), t.$dots && t.$dots.remove(), t.$prevArrow && t.$prevArrow.length && (t.$prevArrow.removeClass("slick-disabled slick-arrow slick-hidden").removeAttr("aria-hidden aria-disabled tabindex").css("display", ""), t.htmlExpr.test(t.options.prevArrow) && t.$prevArrow.remove()), t.$nextArrow && t.$nextArrow.length && (t.$nextArrow.removeClass("slick-disabled slick-arrow slick-hidden").removeAttr("aria-hidden aria-disabled tabindex").css("display", ""), t.htmlExpr.test(t.options.nextArrow) && t.$nextArrow.remove()), t.$slides && (t.$slides.removeClass("slick-slide slick-active slick-center slick-visible slick-current").removeAttr("aria-hidden").removeAttr("data-slick-index").each(function () {
            i(this).attr("style", i(this).data("originalStyling"))
        }), t.$slideTrack.children(this.options.slide).detach(), t.$slideTrack.detach(), t.$list.detach(), t.$slider.append(t.$slides)), t.cleanUpRows(), t.$slider.removeClass("slick-slider"), t.$slider.removeClass("slick-initialized"), t.$slider.removeClass("slick-dotted"), t.unslicked = !0, e || t.$slider.trigger("destroy", [t])
    }, e.prototype.disableTransition = function (i) {
        var e = this,
            t = {};
        t[e.transitionType] = "", e.options.fade === !1 ? e.$slideTrack.css(t) : e.$slides.eq(i).css(t)
    }, e.prototype.fadeSlide = function (i, e) {
        var t = this;
        t.cssTransitions === !1 ? (t.$slides.eq(i).css({
            zIndex: t.options.zIndex
        }), t.$slides.eq(i).animate({
            opacity: 1
        }, t.options.speed, t.options.easing, e)) : (t.applyTransition(i), t.$slides.eq(i).css({
            opacity: 1,
            zIndex: t.options.zIndex
        }), e && setTimeout(function () {
            t.disableTransition(i), e.call()
        }, t.options.speed))
    }, e.prototype.fadeSlideOut = function (i) {
        var e = this;
        e.cssTransitions === !1 ? e.$slides.eq(i).animate({
            opacity: 0,
            zIndex: e.options.zIndex - 2
        }, e.options.speed, e.options.easing) : (e.applyTransition(i), e.$slides.eq(i).css({
            opacity: 0,
            zIndex: e.options.zIndex - 2
        }))
    }, e.prototype.filterSlides = e.prototype.slickFilter = function (i) {
        var e = this;
        null !== i && (e.$slidesCache = e.$slides, e.unload(), e.$slideTrack.children(this.options.slide).detach(), e.$slidesCache.filter(i).appendTo(e.$slideTrack), e.reinit())
    }, e.prototype.focusHandler = function () {
        var e = this;
        e.$slider.off("focus.slick blur.slick").on("focus.slick", "*", function (t) {
            var o = i(this);
            setTimeout(function () {
                e.options.pauseOnFocus && o.is(":focus") && (e.focussed = !0, e.autoPlay())
            }, 0)
        }).on("blur.slick", "*", function (t) {
            i(this);
            e.options.pauseOnFocus && (e.focussed = !1, e.autoPlay())
        })
    }, e.prototype.getCurrent = e.prototype.slickCurrentSlide = function () {
        var i = this;
        return i.currentSlide
    }, e.prototype.getDotCount = function () {
        var i = this,
            e = 0,
            t = 0,
            o = 0;
        if (i.options.infinite === !0)
            if (i.slideCount <= i.options.slidesToShow)++o;
            else
                for (; e < i.slideCount;)++o, e = t + i.options.slidesToScroll, t += i.options.slidesToScroll <= i.options.slidesToShow ? i.options.slidesToScroll : i.options.slidesToShow;
        else if (i.options.centerMode === !0) o = i.slideCount;
        else if (i.options.asNavFor)
            for (; e < i.slideCount;)++o, e = t + i.options.slidesToScroll, t += i.options.slidesToScroll <= i.options.slidesToShow ? i.options.slidesToScroll : i.options.slidesToShow;
        else o = 1 + Math.ceil((i.slideCount - i.options.slidesToShow) / i.options.slidesToScroll);
        return o - 1
    }, e.prototype.getLeft = function (i) {
        var e, t, o, s, n = this,
            r = 0;
        return n.slideOffset = 0, t = n.$slides.first().outerHeight(!0), n.options.infinite === !0 ? (n.slideCount > n.options.slidesToShow && (n.slideOffset = n.slideWidth * n.options.slidesToShow * -1, s = -1, n.options.vertical === !0 && n.options.centerMode === !0 && (2 === n.options.slidesToShow ? s = -1.5 : 1 === n.options.slidesToShow && (s = -2)), r = t * n.options.slidesToShow * s), n.slideCount % n.options.slidesToScroll !== 0 && i + n.options.slidesToScroll > n.slideCount && n.slideCount > n.options.slidesToShow && (i > n.slideCount ? (n.slideOffset = (n.options.slidesToShow - (i - n.slideCount)) * n.slideWidth * -1, r = (n.options.slidesToShow - (i - n.slideCount)) * t * -1) : (n.slideOffset = n.slideCount % n.options.slidesToScroll * n.slideWidth * -1, r = n.slideCount % n.options.slidesToScroll * t * -1))) : i + n.options.slidesToShow > n.slideCount && (n.slideOffset = (i + n.options.slidesToShow - n.slideCount) * n.slideWidth, r = (i + n.options.slidesToShow - n.slideCount) * t), n.slideCount <= n.options.slidesToShow && (n.slideOffset = 0, r = 0), n.options.centerMode === !0 && n.slideCount <= n.options.slidesToShow ? n.slideOffset = n.slideWidth * Math.floor(n.options.slidesToShow) / 2 - n.slideWidth * n.slideCount / 2 : n.options.centerMode === !0 && n.options.infinite === !0 ? n.slideOffset += n.slideWidth * Math.floor(n.options.slidesToShow / 2) - n.slideWidth : n.options.centerMode === !0 && (n.slideOffset = 0, n.slideOffset += n.slideWidth * Math.floor(n.options.slidesToShow / 2)), e = n.options.vertical === !1 ? i * n.slideWidth * -1 + n.slideOffset : i * t * -1 + r, n.options.variableWidth === !0 && (o = n.slideCount <= n.options.slidesToShow || n.options.infinite === !1 ? n.$slideTrack.children(".slick-slide").eq(i) : n.$slideTrack.children(".slick-slide").eq(i + n.options.slidesToShow), e = n.options.rtl === !0 ? o[0] ? (n.$slideTrack.width() - o[0].offsetLeft - o.width()) * -1 : 0 : o[0] ? o[0].offsetLeft * -1 : 0, n.options.centerMode === !0 && (o = n.slideCount <= n.options.slidesToShow || n.options.infinite === !1 ? n.$slideTrack.children(".slick-slide").eq(i) : n.$slideTrack.children(".slick-slide").eq(i + n.options.slidesToShow + 1), e = n.options.rtl === !0 ? o[0] ? (n.$slideTrack.width() - o[0].offsetLeft - o.width()) * -1 : 0 : o[0] ? o[0].offsetLeft * -1 : 0, e += (n.$list.width() - o.outerWidth()) / 2)), e
    }, e.prototype.getOption = e.prototype.slickGetOption = function (i) {
        var e = this;
        return e.options[i]
    }, e.prototype.getNavigableIndexes = function () {
        var i, e = this,
            t = 0,
            o = 0,
            s = [];
        for (e.options.infinite === !1 ? i = e.slideCount : (t = e.options.slidesToScroll * -1, o = e.options.slidesToScroll * -1, i = 2 * e.slideCount); t < i;) s.push(t), t = o + e.options.slidesToScroll, o += e.options.slidesToScroll <= e.options.slidesToShow ? e.options.slidesToScroll : e.options.slidesToShow;
        return s
    }, e.prototype.getSlick = function () {
        return this
    }, e.prototype.getSlideCount = function () {
        var e, t, o, s, n = this;
        return s = n.options.centerMode === !0 ? Math.floor(n.$list.width() / 2) : 0, o = n.swipeLeft * -1 + s, n.options.swipeToSlide === !0 ? (n.$slideTrack.find(".slick-slide").each(function (e, s) {
            var r, l, d;
            if (r = i(s).outerWidth(), l = s.offsetLeft, n.options.centerMode !== !0 && (l += r / 2), d = l + r, o < d) return t = s, !1
        }), e = Math.abs(i(t).attr("data-slick-index") - n.currentSlide) || 1) : n.options.slidesToScroll
    }, e.prototype.goTo = e.prototype.slickGoTo = function (i, e) {
        var t = this;
        t.changeSlide({
            data: {
                message: "index",
                index: parseInt(i)
            }
        }, e)
    }, e.prototype.init = function (e) {
        var t = this;
        i(t.$slider).hasClass("slick-initialized") || (i(t.$slider).addClass("slick-initialized"), t.buildRows(), t.buildOut(), t.setProps(), t.startLoad(), t.loadSlider(), t.initializeEvents(), t.updateArrows(), t.updateDots(), t.checkResponsive(!0), t.focusHandler()), e && t.$slider.trigger("init", [t]), t.options.accessibility === !0 && t.initADA(), t.options.autoplay && (t.paused = !1, t.autoPlay())
    }, e.prototype.initADA = function () {
        var e = this,
            t = Math.ceil(e.slideCount / e.options.slidesToShow),
            o = e.getNavigableIndexes().filter(function (i) {
                return i >= 0 && i < e.slideCount
            });
        e.$slides.add(e.$slideTrack.find(".slick-cloned")).attr({
            "aria-hidden": "true",
            tabindex: "-1"
        }).find("a, input, button, select").attr({
            tabindex: "-1"
        }), null !== e.$dots && (e.$slides.not(e.$slideTrack.find(".slick-cloned")).each(function (t) {
            var s = o.indexOf(t);
            if (i(this).attr({
                role: "tabpanel",
                id: "slick-slide" + e.instanceUid + t,
                tabindex: -1
            }), s !== -1) {
                var n = "slick-slide-control" + e.instanceUid + s;
                i("#" + n).length && i(this).attr({
                    "aria-describedby": n
                })
            }
        }), e.$dots.attr("role", "tablist").find("li").each(function (s) {
            var n = o[s];
            i(this).attr({
                role: "presentation"
            }), i(this).find("button").first().attr({
                role: "tab",
                id: "slick-slide-control" + e.instanceUid + s,
                "aria-controls": "slick-slide" + e.instanceUid + n,
                "aria-label": s + 1 + " of " + t,
                "aria-selected": null,
                tabindex: "-1"
            })
        }).eq(e.currentSlide).find("button").attr({
            "aria-selected": "true",
            tabindex: "0"
        }).end());
        for (var s = e.currentSlide, n = s + e.options.slidesToShow; s < n; s++) e.options.focusOnChange ? e.$slides.eq(s).attr({
            tabindex: "0"
        }) : e.$slides.eq(s).removeAttr("tabindex");
        e.activateADA()
    }, e.prototype.initArrowEvents = function () {
        var i = this;
        i.options.arrows === !0 && i.slideCount > i.options.slidesToShow && (i.$prevArrow.off("click.slick").on("click.slick", {
            message: "previous"
        }, i.changeSlide), i.$nextArrow.off("click.slick").on("click.slick", {
            message: "next"
        }, i.changeSlide), i.options.accessibility === !0 && (i.$prevArrow.on("keydown.slick", i.keyHandler), i.$nextArrow.on("keydown.slick", i.keyHandler)))
    }, e.prototype.initDotEvents = function () {
        var e = this;
        e.options.dots === !0 && e.slideCount > e.options.slidesToShow && (i("li", e.$dots).on("click.slick", {
            message: "index"
        }, e.changeSlide), e.options.accessibility === !0 && e.$dots.on("keydown.slick", e.keyHandler)), e.options.dots === !0 && e.options.pauseOnDotsHover === !0 && e.slideCount > e.options.slidesToShow && i("li", e.$dots).on("mouseenter.slick", i.proxy(e.interrupt, e, !0)).on("mouseleave.slick", i.proxy(e.interrupt, e, !1))
    }, e.prototype.initSlideEvents = function () {
        var e = this;
        e.options.pauseOnHover && (e.$list.on("mouseenter.slick", i.proxy(e.interrupt, e, !0)), e.$list.on("mouseleave.slick", i.proxy(e.interrupt, e, !1)))
    }, e.prototype.initializeEvents = function () {
        var e = this;
        e.initArrowEvents(), e.initDotEvents(), e.initSlideEvents(), e.$list.on("touchstart.slick mousedown.slick", {
            action: "start"
        }, e.swipeHandler), e.$list.on("touchmove.slick mousemove.slick", {
            action: "move"
        }, e.swipeHandler), e.$list.on("touchend.slick mouseup.slick", {
            action: "end"
        }, e.swipeHandler), e.$list.on("touchcancel.slick mouseleave.slick", {
            action: "end"
        }, e.swipeHandler), e.$list.on("click.slick", e.clickHandler), i(document).on(e.visibilityChange, i.proxy(e.visibility, e)), e.options.accessibility === !0 && e.$list.on("keydown.slick", e.keyHandler), e.options.focusOnSelect === !0 && i(e.$slideTrack).children().on("click.slick", e.selectHandler), i(window).on("orientationchange.slick.slick-" + e.instanceUid, i.proxy(e.orientationChange, e)), i(window).on("resize.slick.slick-" + e.instanceUid, i.proxy(e.resize, e)), i("[draggable!=true]", e.$slideTrack).on("dragstart", e.preventDefault), i(window).on("load.slick.slick-" + e.instanceUid, e.setPosition), i(e.setPosition)
    }, e.prototype.initUI = function () {
        var i = this;
        i.options.arrows === !0 && i.slideCount > i.options.slidesToShow && (i.$prevArrow.show(), i.$nextArrow.show()), i.options.dots === !0 && i.slideCount > i.options.slidesToShow && i.$dots.show()
    }, e.prototype.keyHandler = function (i) {
        var e = this;
        i.target.tagName.match("TEXTAREA|INPUT|SELECT") || (37 === i.keyCode && e.options.accessibility === !0 ? e.changeSlide({
            data: {
                message: e.options.rtl === !0 ? "next" : "previous"
            }
        }) : 39 === i.keyCode && e.options.accessibility === !0 && e.changeSlide({
            data: {
                message: e.options.rtl === !0 ? "previous" : "next"
            }
        }))
    }, e.prototype.lazyLoad = function () {
        function e(e) {
            i("img[data-lazy]", e).each(function () {
                var e = i(this),
                    t = i(this).attr("data-lazy"),
                    o = i(this).attr("data-srcset"),
                    s = i(this).attr("data-sizes") || r.$slider.attr("data-sizes"),
                    n = document.createElement("img");
                n.onload = function () {
                    e.animate({
                        opacity: 0
                    }, 100, function () {
                        o && (e.attr("srcset", o), s && e.attr("sizes", s)), e.attr("src", t).animate({
                            opacity: 1
                        }, 200, function () {
                            e.removeAttr("data-lazy data-srcset data-sizes").removeClass("slick-loading")
                        }), r.$slider.trigger("lazyLoaded", [r, e, t])
                    })
                }, n.onerror = function () {
                    e.removeAttr("data-lazy").removeClass("slick-loading").addClass("slick-lazyload-error"), r.$slider.trigger("lazyLoadError", [r, e, t])
                }, n.src = t
            })
        }
        var t, o, s, n, r = this;
        if (r.options.centerMode === !0 ? r.options.infinite === !0 ? (s = r.currentSlide + (r.options.slidesToShow / 2 + 1), n = s + r.options.slidesToShow + 2) : (s = Math.max(0, r.currentSlide - (r.options.slidesToShow / 2 + 1)), n = 2 + (r.options.slidesToShow / 2 + 1) + r.currentSlide) : (s = r.options.infinite ? r.options.slidesToShow + r.currentSlide : r.currentSlide, n = Math.ceil(s + r.options.slidesToShow), r.options.fade === !0 && (s > 0 && s-- , n <= r.slideCount && n++)), t = r.$slider.find(".slick-slide").slice(s, n), "anticipated" === r.options.lazyLoad)
            for (var l = s - 1, d = n, a = r.$slider.find(".slick-slide"), c = 0; c < r.options.slidesToScroll; c++) l < 0 && (l = r.slideCount - 1), t = t.add(a.eq(l)), t = t.add(a.eq(d)), l-- , d++;
        e(t), r.slideCount <= r.options.slidesToShow ? (o = r.$slider.find(".slick-slide"), e(o)) : r.currentSlide >= r.slideCount - r.options.slidesToShow ? (o = r.$slider.find(".slick-cloned").slice(0, r.options.slidesToShow), e(o)) : 0 === r.currentSlide && (o = r.$slider.find(".slick-cloned").slice(r.options.slidesToShow * -1), e(o))
    }, e.prototype.loadSlider = function () {
        var i = this;
        i.setPosition(), i.$slideTrack.css({
            opacity: 1
        }), i.$slider.removeClass("slick-loading"), i.initUI(), "progressive" === i.options.lazyLoad && i.progressiveLazyLoad()
    }, e.prototype.next = e.prototype.slickNext = function () {
        var i = this;
        i.changeSlide({
            data: {
                message: "next"
            }
        })
    }, e.prototype.orientationChange = function () {
        var i = this;
        i.checkResponsive(), i.setPosition()
    }, e.prototype.pause = e.prototype.slickPause = function () {
        var i = this;
        i.autoPlayClear(), i.paused = !0
    }, e.prototype.play = e.prototype.slickPlay = function () {
        var i = this;
        i.autoPlay(), i.options.autoplay = !0, i.paused = !1, i.focussed = !1, i.interrupted = !1
    }, e.prototype.postSlide = function (e) {
        var t = this;
        if (!t.unslicked && (t.$slider.trigger("afterChange", [t, e]), t.animating = !1, t.slideCount > t.options.slidesToShow && t.setPosition(), t.swipeLeft = null, t.options.autoplay && t.autoPlay(), t.options.accessibility === !0 && (t.initADA(), t.options.focusOnChange))) {
            var o = i(t.$slides.get(t.currentSlide));
            o.attr("tabindex", 0).focus()
        }
    }, e.prototype.prev = e.prototype.slickPrev = function () {
        var i = this;
        i.changeSlide({
            data: {
                message: "previous"
            }
        })
    }, e.prototype.preventDefault = function (i) {
        i.preventDefault()
    }, e.prototype.progressiveLazyLoad = function (e) {
        e = e || 1;
        var t, o, s, n, r, l = this,
            d = i("img[data-lazy]", l.$slider);
        d.length ? (t = d.first(), o = t.attr("data-lazy"), s = t.attr("data-srcset"), n = t.attr("data-sizes") || l.$slider.attr("data-sizes"), r = document.createElement("img"), r.onload = function () {
            s && (t.attr("srcset", s), n && t.attr("sizes", n)), t.attr("src", o).removeAttr("data-lazy data-srcset data-sizes").removeClass("slick-loading"), l.options.adaptiveHeight === !0 && l.setPosition(), l.$slider.trigger("lazyLoaded", [l, t, o]), l.progressiveLazyLoad()
        }, r.onerror = function () {
            e < 3 ? setTimeout(function () {
                l.progressiveLazyLoad(e + 1)
            }, 500) : (t.removeAttr("data-lazy").removeClass("slick-loading").addClass("slick-lazyload-error"), l.$slider.trigger("lazyLoadError", [l, t, o]), l.progressiveLazyLoad())
        }, r.src = o) : l.$slider.trigger("allImagesLoaded", [l])
    }, e.prototype.refresh = function (e) {
        var t, o, s = this;
        o = s.slideCount - s.options.slidesToShow, !s.options.infinite && s.currentSlide > o && (s.currentSlide = o), s.slideCount <= s.options.slidesToShow && (s.currentSlide = 0), t = s.currentSlide, s.destroy(!0), i.extend(s, s.initials, {
            currentSlide: t
        }), s.init(), e || s.changeSlide({
            data: {
                message: "index",
                index: t
            }
        }, !1)
    }, e.prototype.registerBreakpoints = function () {
        var e, t, o, s = this,
            n = s.options.responsive || null;
        if ("array" === i.type(n) && n.length) {
            s.respondTo = s.options.respondTo || "window";
            for (e in n)
                if (o = s.breakpoints.length - 1, n.hasOwnProperty(e)) {
                    for (t = n[e].breakpoint; o >= 0;) s.breakpoints[o] && s.breakpoints[o] === t && s.breakpoints.splice(o, 1), o--;
                    s.breakpoints.push(t), s.breakpointSettings[t] = n[e].settings
                }
            s.breakpoints.sort(function (i, e) {
                return s.options.mobileFirst ? i - e : e - i
            })
        }
    }, e.prototype.reinit = function () {
        var e = this;
        e.$slides = e.$slideTrack.children(e.options.slide).addClass("slick-slide"), e.slideCount = e.$slides.length, e.currentSlide >= e.slideCount && 0 !== e.currentSlide && (e.currentSlide = e.currentSlide - e.options.slidesToScroll), e.slideCount <= e.options.slidesToShow && (e.currentSlide = 0), e.registerBreakpoints(), e.setProps(), e.setupInfinite(), e.buildArrows(), e.updateArrows(), e.initArrowEvents(), e.buildDots(), e.updateDots(), e.initDotEvents(), e.cleanUpSlideEvents(), e.initSlideEvents(), e.checkResponsive(!1, !0), e.options.focusOnSelect === !0 && i(e.$slideTrack).children().on("click.slick", e.selectHandler), e.setSlideClasses("number" == typeof e.currentSlide ? e.currentSlide : 0), e.setPosition(), e.focusHandler(), e.paused = !e.options.autoplay, e.autoPlay(), e.$slider.trigger("reInit", [e])
    }, e.prototype.resize = function () {
        var e = this;
        i(window).width() !== e.windowWidth && (clearTimeout(e.windowDelay), e.windowDelay = window.setTimeout(function () {
            e.windowWidth = i(window).width(), e.checkResponsive(), e.unslicked || e.setPosition()
        }, 50))
    }, e.prototype.removeSlide = e.prototype.slickRemove = function (i, e, t) {
        var o = this;
        return "boolean" == typeof i ? (e = i, i = e === !0 ? 0 : o.slideCount - 1) : i = e === !0 ? --i : i, !(o.slideCount < 1 || i < 0 || i > o.slideCount - 1) && (o.unload(), t === !0 ? o.$slideTrack.children().remove() : o.$slideTrack.children(this.options.slide).eq(i).remove(), o.$slides = o.$slideTrack.children(this.options.slide), o.$slideTrack.children(this.options.slide).detach(), o.$slideTrack.append(o.$slides), o.$slidesCache = o.$slides, void o.reinit())
    }, e.prototype.setCSS = function (i) {
        var e, t, o = this,
            s = {};
        o.options.rtl === !0 && (i = -i), e = "left" == o.positionProp ? Math.ceil(i) + "px" : "0px", t = "top" == o.positionProp ? Math.ceil(i) + "px" : "0px", s[o.positionProp] = i, o.transformsEnabled === !1 ? o.$slideTrack.css(s) : (s = {}, o.cssTransitions === !1 ? (s[o.animType] = "translate(" + e + ", " + t + ")", o.$slideTrack.css(s)) : (s[o.animType] = "translate3d(" + e + ", " + t + ", 0px)", o.$slideTrack.css(s)))
    }, e.prototype.setDimensions = function () {
        var i = this;
        i.options.vertical === !1 ? i.options.centerMode === !0 && i.$list.css({
            padding: "0px " + i.options.centerPadding
        }) : (i.$list.height(i.$slides.first().outerHeight(!0) * i.options.slidesToShow), i.options.centerMode === !0 && i.$list.css({
            padding: i.options.centerPadding + " 0px"
        })), i.listWidth = i.$list.width(), i.listHeight = i.$list.height(), i.options.vertical === !1 && i.options.variableWidth === !1 ? (i.slideWidth = Math.ceil(i.listWidth / i.options.slidesToShow), i.$slideTrack.width(Math.ceil(i.slideWidth * i.$slideTrack.children(".slick-slide").length))) : i.options.variableWidth === !0 ? i.$slideTrack.width(5e3 * i.slideCount) : (i.slideWidth = Math.ceil(i.listWidth), i.$slideTrack.height(Math.ceil(i.$slides.first().outerHeight(!0) * i.$slideTrack.children(".slick-slide").length)));
        var e = i.$slides.first().outerWidth(!0) - i.$slides.first().width();
        i.options.variableWidth === !1 && i.$slideTrack.children(".slick-slide").width(i.slideWidth - e)
    }, e.prototype.setFade = function () {
        var e, t = this;
        t.$slides.each(function (o, s) {
            e = t.slideWidth * o * -1, t.options.rtl === !0 ? i(s).css({
                position: "relative",
                right: e,
                top: 0,
                zIndex: t.options.zIndex - 2,
                opacity: 0
            }) : i(s).css({
                position: "relative",
                left: e,
                top: 0,
                zIndex: t.options.zIndex - 2,
                opacity: 0
            })
        }), t.$slides.eq(t.currentSlide).css({
            zIndex: t.options.zIndex - 1,
            opacity: 1
        })
    }, e.prototype.setHeight = function () {
        var i = this;
        if (1 === i.options.slidesToShow && i.options.adaptiveHeight === !0 && i.options.vertical === !1) {
            var e = i.$slides.eq(i.currentSlide).outerHeight(!0);
            i.$list.css("height", e)
        }
    }, e.prototype.setOption = e.prototype.slickSetOption = function () {
        var e, t, o, s, n, r = this,
            l = !1;
        if ("object" === i.type(arguments[0]) ? (o = arguments[0], l = arguments[1], n = "multiple") : "string" === i.type(arguments[0]) && (o = arguments[0], s = arguments[1], l = arguments[2], "responsive" === arguments[0] && "array" === i.type(arguments[1]) ? n = "responsive" : "undefined" != typeof arguments[1] && (n = "single")), "single" === n) r.options[o] = s;
        else if ("multiple" === n) i.each(o, function (i, e) {
            r.options[i] = e
        });
        else if ("responsive" === n)
            for (t in s)
                if ("array" !== i.type(r.options.responsive)) r.options.responsive = [s[t]];
                else {
                    for (e = r.options.responsive.length - 1; e >= 0;) r.options.responsive[e].breakpoint === s[t].breakpoint && r.options.responsive.splice(e, 1), e--;
                    r.options.responsive.push(s[t])
                }
        l && (r.unload(), r.reinit())
    }, e.prototype.setPosition = function () {
        var i = this;
        i.setDimensions(), i.setHeight(), i.options.fade === !1 ? i.setCSS(i.getLeft(i.currentSlide)) : i.setFade(), i.$slider.trigger("setPosition", [i])
    }, e.prototype.setProps = function () {
        var i = this,
            e = document.body.style;
        i.positionProp = i.options.vertical === !0 ? "top" : "left", "top" === i.positionProp ? i.$slider.addClass("slick-vertical") : i.$slider.removeClass("slick-vertical"), void 0 === e.WebkitTransition && void 0 === e.MozTransition && void 0 === e.msTransition || i.options.useCSS === !0 && (i.cssTransitions = !0), i.options.fade && ("number" == typeof i.options.zIndex ? i.options.zIndex < 3 && (i.options.zIndex = 3) : i.options.zIndex = i.defaults.zIndex), void 0 !== e.OTransform && (i.animType = "OTransform", i.transformType = "-o-transform", i.transitionType = "OTransition", void 0 === e.perspectiveProperty && void 0 === e.webkitPerspective && (i.animType = !1)), void 0 !== e.MozTransform && (i.animType = "MozTransform", i.transformType = "-moz-transform", i.transitionType = "MozTransition", void 0 === e.perspectiveProperty && void 0 === e.MozPerspective && (i.animType = !1)), void 0 !== e.webkitTransform && (i.animType = "webkitTransform", i.transformType = "-webkit-transform", i.transitionType = "webkitTransition", void 0 === e.perspectiveProperty && void 0 === e.webkitPerspective && (i.animType = !1)), void 0 !== e.msTransform && (i.animType = "msTransform", i.transformType = "-ms-transform", i.transitionType = "msTransition", void 0 === e.msTransform && (i.animType = !1)), void 0 !== e.transform && i.animType !== !1 && (i.animType = "transform", i.transformType = "transform", i.transitionType = "transition"), i.transformsEnabled = i.options.useTransform && null !== i.animType && i.animType !== !1
    }, e.prototype.setSlideClasses = function (i) {
        var e, t, o, s, n = this;
        if (t = n.$slider.find(".slick-slide").removeClass("slick-active slick-center slick-current").attr("aria-hidden", "true"), n.$slides.eq(i).addClass("slick-current"), n.options.centerMode === !0) {
            var r = n.options.slidesToShow % 2 === 0 ? 1 : 0;
            e = Math.floor(n.options.slidesToShow / 2), n.options.infinite === !0 && (i >= e && i <= n.slideCount - 1 - e ? n.$slides.slice(i - e + r, i + e + 1).addClass("slick-active").attr("aria-hidden", "false") : (o = n.options.slidesToShow + i, t.slice(o - e + 1 + r, o + e + 2).addClass("slick-active").attr("aria-hidden", "false")), 0 === i ? t.eq(t.length - 1 - n.options.slidesToShow).addClass("slick-center") : i === n.slideCount - 1 && t.eq(n.options.slidesToShow).addClass("slick-center")), n.$slides.eq(i).addClass("slick-center")
        } else i >= 0 && i <= n.slideCount - n.options.slidesToShow ? n.$slides.slice(i, i + n.options.slidesToShow).addClass("slick-active").attr("aria-hidden", "false") : t.length <= n.options.slidesToShow ? t.addClass("slick-active").attr("aria-hidden", "false") : (s = n.slideCount % n.options.slidesToShow, o = n.options.infinite === !0 ? n.options.slidesToShow + i : i, n.options.slidesToShow == n.options.slidesToScroll && n.slideCount - i < n.options.slidesToShow ? t.slice(o - (n.options.slidesToShow - s), o + s).addClass("slick-active").attr("aria-hidden", "false") : t.slice(o, o + n.options.slidesToShow).addClass("slick-active").attr("aria-hidden", "false"));
        "ondemand" !== n.options.lazyLoad && "anticipated" !== n.options.lazyLoad || n.lazyLoad()
    }, e.prototype.setupInfinite = function () {
        var e, t, o, s = this;
        if (s.options.fade === !0 && (s.options.centerMode = !1), s.options.infinite === !0 && s.options.fade === !1 && (t = null, s.slideCount > s.options.slidesToShow)) {
            for (o = s.options.centerMode === !0 ? s.options.slidesToShow + 1 : s.options.slidesToShow, e = s.slideCount; e > s.slideCount - o; e -= 1) t = e - 1, i(s.$slides[t]).clone(!0).attr("id", "").attr("data-slick-index", t - s.slideCount).prependTo(s.$slideTrack).addClass("slick-cloned");
            for (e = 0; e < o + s.slideCount; e += 1) t = e, i(s.$slides[t]).clone(!0).attr("id", "").attr("data-slick-index", t + s.slideCount).appendTo(s.$slideTrack).addClass("slick-cloned");
            s.$slideTrack.find(".slick-cloned").find("[id]").each(function () {
                i(this).attr("id", "")
            })
        }
    }, e.prototype.interrupt = function (i) {
        var e = this;
        i || e.autoPlay(), e.interrupted = i
    }, e.prototype.selectHandler = function (e) {
        var t = this,
            o = i(e.target).is(".slick-slide") ? i(e.target) : i(e.target).parents(".slick-slide"),
            s = parseInt(o.attr("data-slick-index"));
        return s || (s = 0), t.slideCount <= t.options.slidesToShow ? void t.slideHandler(s, !1, !0) : void t.slideHandler(s)
    }, e.prototype.slideHandler = function (i, e, t) {
        var o, s, n, r, l, d = null,
            a = this;
        if (e = e || !1, !(a.animating === !0 && a.options.waitForAnimate === !0 || a.options.fade === !0 && a.currentSlide === i)) return e === !1 && a.asNavFor(i), o = i, d = a.getLeft(o), r = a.getLeft(a.currentSlide), a.currentLeft = null === a.swipeLeft ? r : a.swipeLeft, a.options.infinite === !1 && a.options.centerMode === !1 && (i < 0 || i > a.getDotCount() * a.options.slidesToScroll) ? void (a.options.fade === !1 && (o = a.currentSlide, t !== !0 && a.slideCount > a.options.slidesToShow ? a.animateSlide(r, function () {
            a.postSlide(o)
        }) : a.postSlide(o))) : a.options.infinite === !1 && a.options.centerMode === !0 && (i < 0 || i > a.slideCount - a.options.slidesToScroll) ? void (a.options.fade === !1 && (o = a.currentSlide, t !== !0 && a.slideCount > a.options.slidesToShow ? a.animateSlide(r, function () {
            a.postSlide(o)
        }) : a.postSlide(o))) : (a.options.autoplay && clearInterval(a.autoPlayTimer), s = o < 0 ? a.slideCount % a.options.slidesToScroll !== 0 ? a.slideCount - a.slideCount % a.options.slidesToScroll : a.slideCount + o : o >= a.slideCount ? a.slideCount % a.options.slidesToScroll !== 0 ? 0 : o - a.slideCount : o, a.animating = !0, a.$slider.trigger("beforeChange", [a, a.currentSlide, s]), n = a.currentSlide, a.currentSlide = s, a.setSlideClasses(a.currentSlide), a.options.asNavFor && (l = a.getNavTarget(), l = l.slick("getSlick"), l.slideCount <= l.options.slidesToShow && l.setSlideClasses(a.currentSlide)), a.updateDots(), a.updateArrows(), a.options.fade === !0 ? (t !== !0 ? (a.fadeSlideOut(n), a.fadeSlide(s, function () {
            a.postSlide(s)
        })) : a.postSlide(s), void a.animateHeight()) : void (t !== !0 && a.slideCount > a.options.slidesToShow ? a.animateSlide(d, function () {
            a.postSlide(s)
        }) : a.postSlide(s)))
    }, e.prototype.startLoad = function () {
        var i = this;
        i.options.arrows === !0 && i.slideCount > i.options.slidesToShow && (i.$prevArrow.hide(), i.$nextArrow.hide()), i.options.dots === !0 && i.slideCount > i.options.slidesToShow && i.$dots.hide(), i.$slider.addClass("slick-loading")
    }, e.prototype.swipeDirection = function () {
        var i, e, t, o, s = this;
        return i = s.touchObject.startX - s.touchObject.curX, e = s.touchObject.startY - s.touchObject.curY, t = Math.atan2(e, i), o = Math.round(180 * t / Math.PI), o < 0 && (o = 360 - Math.abs(o)), o <= 45 && o >= 0 ? s.options.rtl === !1 ? "left" : "right" : o <= 360 && o >= 315 ? s.options.rtl === !1 ? "left" : "right" : o >= 135 && o <= 225 ? s.options.rtl === !1 ? "right" : "left" : s.options.verticalSwiping === !0 ? o >= 35 && o <= 135 ? "down" : "up" : "vertical"
    }, e.prototype.swipeEnd = function (i) {
        var e, t, o = this;
        if (o.dragging = !1, o.swiping = !1, o.scrolling) return o.scrolling = !1, !1;
        if (o.interrupted = !1, o.shouldClick = !(o.touchObject.swipeLength > 10), void 0 === o.touchObject.curX) return !1;
        if (o.touchObject.edgeHit === !0 && o.$slider.trigger("edge", [o, o.swipeDirection()]), o.touchObject.swipeLength >= o.touchObject.minSwipe) {
            switch (t = o.swipeDirection()) {
                case "left":
                case "down":
                    e = o.options.swipeToSlide ? o.checkNavigable(o.currentSlide + o.getSlideCount()) : o.currentSlide + o.getSlideCount(), o.currentDirection = 0;
                    break;
                case "right":
                case "up":
                    e = o.options.swipeToSlide ? o.checkNavigable(o.currentSlide - o.getSlideCount()) : o.currentSlide - o.getSlideCount(), o.currentDirection = 1
            }
            "vertical" != t && (o.slideHandler(e), o.touchObject = {}, o.$slider.trigger("swipe", [o, t]))
        } else o.touchObject.startX !== o.touchObject.curX && (o.slideHandler(o.currentSlide), o.touchObject = {})
    }, e.prototype.swipeHandler = function (i) {
        var e = this;
        if (!(e.options.swipe === !1 || "ontouchend" in document && e.options.swipe === !1 || e.options.draggable === !1 && i.type.indexOf("mouse") !== -1)) switch (e.touchObject.fingerCount = i.originalEvent && void 0 !== i.originalEvent.touches ? i.originalEvent.touches.length : 1, e.touchObject.minSwipe = e.listWidth / e.options.touchThreshold, e.options.verticalSwiping === !0 && (e.touchObject.minSwipe = e.listHeight / e.options.touchThreshold), i.data.action) {
            case "start":
                e.swipeStart(i);
                break;
            case "move":
                e.swipeMove(i);
                break;
            case "end":
                e.swipeEnd(i)
        }
    }, e.prototype.swipeMove = function (i) {
        var e, t, o, s, n, r, l = this;
        return n = void 0 !== i.originalEvent ? i.originalEvent.touches : null, !(!l.dragging || l.scrolling || n && 1 !== n.length) && (e = l.getLeft(l.currentSlide), l.touchObject.curX = void 0 !== n ? n[0].pageX : i.clientX, l.touchObject.curY = void 0 !== n ? n[0].pageY : i.clientY, l.touchObject.swipeLength = Math.round(Math.sqrt(Math.pow(l.touchObject.curX - l.touchObject.startX, 2))), r = Math.round(Math.sqrt(Math.pow(l.touchObject.curY - l.touchObject.startY, 2))), !l.options.verticalSwiping && !l.swiping && r > 4 ? (l.scrolling = !0, !1) : (l.options.verticalSwiping === !0 && (l.touchObject.swipeLength = r), t = l.swipeDirection(), void 0 !== i.originalEvent && l.touchObject.swipeLength > 4 && (l.swiping = !0, i.preventDefault()), s = (l.options.rtl === !1 ? 1 : -1) * (l.touchObject.curX > l.touchObject.startX ? 1 : -1), l.options.verticalSwiping === !0 && (s = l.touchObject.curY > l.touchObject.startY ? 1 : -1), o = l.touchObject.swipeLength, l.touchObject.edgeHit = !1, l.options.infinite === !1 && (0 === l.currentSlide && "right" === t || l.currentSlide >= l.getDotCount() && "left" === t) && (o = l.touchObject.swipeLength * l.options.edgeFriction, l.touchObject.edgeHit = !0), l.options.vertical === !1 ? l.swipeLeft = e + o * s : l.swipeLeft = e + o * (l.$list.height() / l.listWidth) * s, l.options.verticalSwiping === !0 && (l.swipeLeft = e + o * s), l.options.fade !== !0 && l.options.touchMove !== !1 && (l.animating === !0 ? (l.swipeLeft = null, !1) : void l.setCSS(l.swipeLeft))))
    }, e.prototype.swipeStart = function (i) {
        var e, t = this;
        return t.interrupted = !0, 1 !== t.touchObject.fingerCount || t.slideCount <= t.options.slidesToShow ? (t.touchObject = {}, !1) : (void 0 !== i.originalEvent && void 0 !== i.originalEvent.touches && (e = i.originalEvent.touches[0]), t.touchObject.startX = t.touchObject.curX = void 0 !== e ? e.pageX : i.clientX, t.touchObject.startY = t.touchObject.curY = void 0 !== e ? e.pageY : i.clientY, void (t.dragging = !0))
    }, e.prototype.unfilterSlides = e.prototype.slickUnfilter = function () {
        var i = this;
        null !== i.$slidesCache && (i.unload(), i.$slideTrack.children(this.options.slide).detach(), i.$slidesCache.appendTo(i.$slideTrack), i.reinit())
    }, e.prototype.unload = function () {
        var e = this;
        i(".slick-cloned", e.$slider).remove(), e.$dots && e.$dots.remove(), e.$prevArrow && e.htmlExpr.test(e.options.prevArrow) && e.$prevArrow.remove(), e.$nextArrow && e.htmlExpr.test(e.options.nextArrow) && e.$nextArrow.remove(), e.$slides.removeClass("slick-slide slick-active slick-visible slick-current").attr("aria-hidden", "true").css("width", "")
    }, e.prototype.unslick = function (i) {
        var e = this;
        e.$slider.trigger("unslick", [e, i]), e.destroy()
    }, e.prototype.updateArrows = function () {
        var i, e = this;
        i = Math.floor(e.options.slidesToShow / 2), e.options.arrows === !0 && e.slideCount > e.options.slidesToShow && !e.options.infinite && (e.$prevArrow.removeClass("slick-disabled").attr("aria-disabled", "false"), e.$nextArrow.removeClass("slick-disabled").attr("aria-disabled", "false"), 0 === e.currentSlide ? (e.$prevArrow.addClass("slick-disabled").attr("aria-disabled", "true"), e.$nextArrow.removeClass("slick-disabled").attr("aria-disabled", "false")) : e.currentSlide >= e.slideCount - e.options.slidesToShow && e.options.centerMode === !1 ? (e.$nextArrow.addClass("slick-disabled").attr("aria-disabled", "true"), e.$prevArrow.removeClass("slick-disabled").attr("aria-disabled", "false")) : e.currentSlide >= e.slideCount - 1 && e.options.centerMode === !0 && (e.$nextArrow.addClass("slick-disabled").attr("aria-disabled", "true"), e.$prevArrow.removeClass("slick-disabled").attr("aria-disabled", "false")))
    }, e.prototype.updateDots = function () {
        var i = this;
        null !== i.$dots && (i.$dots.find("li").removeClass("slick-active").end(), i.$dots.find("li").eq(Math.floor(i.currentSlide / i.options.slidesToScroll)).addClass("slick-active"))
    }, e.prototype.visibility = function () {
        var i = this;
        i.options.autoplay && (document[i.hidden] ? i.interrupted = !0 : i.interrupted = !1)
    }, i.fn.slick = function () {
        var i, t, o = this,
            s = arguments[0],
            n = Array.prototype.slice.call(arguments, 1),
            r = o.length;
        for (i = 0; i < r; i++)
            if ("object" == typeof s || "undefined" == typeof s ? o[i].slick = new e(o[i], s) : t = o[i].slick[s].apply(o[i].slick, n), "undefined" != typeof t) return t;
        return o
    }
});
! function (a, i) {
    "use strict";
    a("body,html").hasClass("rtl");
    a(document).ready(function () {
        a('[data-ride="vodi-slick-carousel"]').each(function () {
            var i = !1;
            "undefined" !== a(this).data("slick") && 0 < a(this).find(a(this).data("wrap")).length ? (i = a(this).find(a(this).data("wrap"))).data("slick", a(this).data("slick")) : "undefined" !== a(this).data("slick") && a(this).is(a(this).data("wrap")) && (i = a(this)), i && i.slick()
        }), a('a[data-toggle="tab"]').on("shown.bs.tab", function (i) {
            var t = a(i.target).attr("href");
            a(t).find('[data-ride="vodi-slick-carousel"]').each(function () {
                var i = a(this),
                    t = a(this).data("wrap");
                0 < a(i).find(t).length && a(i).find(t).slick("setPosition")
            })
        }), a(".site_header__primary-nav li.yamm-fw.menu-item-has-children").on("mouseenter", function (i) {
            var t = a(this).children(".sub-menu");
            a(t).find('[data-ride="vodi-slick-carousel"]').each(function () {
                var i = a(this),
                    t = i.data("wrap");
                0 < a(i).find(t).length && a(i).find(t).slick("setPosition")
            })
        })
    })
}(jQuery, window);
! function (l, e) {
    "use strict";
    l("body,html").hasClass("rtl");
    l(".article__attachment--gallery > .gallery").each(function () {
        var e, a, t, i = l(this),
            s = "";
        t = (s = i.attr("class")).indexOf("gallery-columns-") + 16, a = Number(s.substr(t, 1)), e = !(10 < i.find(".gallery-item").length / a), i.slick({
            slidesToShow: a,
            slidesToScroll: a,
            dots: e,
            arrows: !e
        })
    }), l('.movies-carousel__inner:not([data-ride="vodi-slick-carousel"])').each(function () {
        l(this).slick()
    }), l('.videos-carousel__inner:not([data-ride="vodi-slick-carousel"])').each(function () {
        l(this).slick()
    }), l('.episodes-carousel__inner:not([data-ride="vodi-slick-carousel"])').each(function () {
        l(this).slick()
    }), l('.movies-collection-carousel__inner:not([data-ride="vodi-slick-carousel"])').each(function () {
        l(this).slick()
    }), l(".single-video__comments-link__inner > a").on("click", function (e) {
        if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") && location.hostname == this.hostname) {
            var a = l(this.hash);
            if ((a = a.length ? a : l("[name=" + this.hash.slice(1) + "]")).length) return l("html, body").animate({
                scrollTop: a.offset().top
            }, 1e3), !1
        }
    }), l(".site-header__offcanvas .navbar-toggler").on("click", function () {
        0 < l(this).parents(".stuck").length && l("html, body").animate({
            scrollTop: l("body")
        }, 0), l(this).closest(".site-header__offcanvas").toggleClass("toggled"), l("body").toggleClass("off-canvas-active")
    }), l(document).on("click", function (e) {
        l(".site-header__offcanvas").hasClass("toggled") && (l(".navbar-toggler").is(e.target) || 0 !== l(".navbar-toggler").has(e.target).length || l(".offcanvas-collapse").is(e.target) || 0 !== l(".offcanvas-collapse").has(e.target).length || (l(".site-header__offcanvas").removeClass("toggled"), l("body").removeClass("off-canvas-active")))
    }), l(".site_header__primary-nav, .site_header__secondary-nav, .site_header__secondary-nav-v3, .site_header__navbar-primary").on("mouseleave", function () {
        l(this).removeClass("animated-dropdown")
    }), l(".site_header__primary-nav .menu-item, .site_header__secondary-nav .menu-item, .site_header__secondary-nav-v3 .menu-item, .site_header__navbar-primary .menu-item").on("mouseenter", function () {
        var e = l(this),
            a = e.parents(".site_header__primary-nav, .site_header__secondary-nav, .site_header__secondary-nav-v3, .site_header__navbar-primary"),
            t = e.parents(".vodi-animate-dropdown");
        if (0 < a.length && (t = a), e.hasClass("menu-item-has-children")) t.hasClass("animated-dropdown") || setTimeout(function () {
            t.addClass("animated-dropdown")
        }, 200);
        else if (t.hasClass("animated-dropdown")) {
            e.parents(".menu-item-has-children").length <= 0 && t.removeClass("animated-dropdown")
        }
    }), l(".vtw-tabbed-tabs").each(function () {
        var i = l(this);
        i.on("click", ".vtw-tabbed-nav li", function (e) {
            e.preventDefault();
            var a = l(this),
                t = a.attr("data-tab");
            void 0 !== t && (l(".vtw-tabbed-nav li", i).removeClass("tab-active"), a.addClass("tab-active"), l(".vtw-tabbed-cont", i).removeClass("tab-active"), l(".vtw-tabbed-cont." + t, i).addClass("tab-active"))
        }), l(".vtw-tabbed-nav li", i).eq(0).trigger("click")
    }), l(".site-header__inner .site-header__search .search-btn").on("click", function (e) {
        l(this).closest(".site-header__search").toggleClass("show")
    }), l(document).on("click", function (e) {
        l(".site-header__search").hasClass("show") && (l(".site-header__search").is(e.target) || 0 !== l(".site-header__search").has(e.target).length || (l(".site-header__search").removeClass("show"), l(".search-form").removeClass("animated fadeInRight")))
    }), l(".handheld-sidebar-toggle .sidebar-toggler").on("click", function () {
        l(this).closest(".site-content").toggleClass("active-hh-sidebar")
    }), l(document).on("click", function (e) {
        l(".site-content").hasClass("active-hh-sidebar") && (l(".handheld-sidebar-toggle").is(e.target) || 0 !== l(".handheld-sidebar-toggle").has(e.target).length || l("#secondary").is(e.target) || 0 !== l("#secondary").has(e.target).length || l(".site-content").toggleClass("active-hh-sidebar"))
        })
        //, l(".count-down-timer")
        //    .each(function () {
        //var e, a, t, i, s, n, o, r = l(this),
        //    d = 1e3 * (l(r).children(".count-down-timer-end").text() - 3600 * vodi_options.wp_local_time_offset);
        //setInterval(function () {
        //    s = (s = new Date).toUTCString(), n = Date.parse(s), o = (d - n) / 1e3, e = parseInt(o / 86400), o %= 86400, a = parseInt(o / 3600), o %= 3600, t = parseInt(o / 60), i = parseInt(o % 60), l(r).find(".days > .value").html(e), l(r).find(".hours > .value").html(a), l(r).find(".minutes > .value").html(t), l(r).find(".seconds > .value").html(i)
        //}
        //,
        //1e3)
        //    }),
        l(document).ready(function () {
        if ("1" == vodi_options.enable_vodi_readmore && (new Readmore(".single-episode-v1 .episode__description > div, .single-episode-v2 .episode__description > div, .single-episode-v2 .episode__description > div, .single-episode-v4 .episode__short-description > p, .single-movie-v1 .movie__description > div, .single-movie-v2 .movie__description > div, .single-movie-v3 .movie__description > div, .single-movie-v4 .movie__info--head .movie__short-description > p", vodi_options.vodi_episode_readmore_data), new Readmore(".single-video .single-video__description > div", vodi_options.vodi_video_readmore_data)), l(".archive-view-switcher").on("click", ".nav-link", function () {
            var e = l(this),
                a = e.data("archiveClass"),
                t = e.data("archiveColumns"),
                i = "columns-" + t,
                s = "columns-" + (parseInt(t) - 1),
                n = l(".vodi-archive-wrapper > div");
            l(".vodi-archive-wrapper").attr("data-view", a), "grid-extended" == a ? (n.removeClass(i), n.addClass(s)) : (n.removeClass(s), n.addClass(i))
        }), 1200 <= l(e).width() && "1" == vodi_options.enable_sticky_header && 0 < l("#page").find(".stick-this").length) new Waypoint.Sticky({
            element: l(".stick-this")[0],
            stuckClass: "stuck animated fadeInDown faster",
            offset: function () {
                return -this.element.clientHeight
            }
        });
        if (l(".transparent").parent(".sticky-wrapper").addClass("sticky-wrapper-transparent"), l(e).width() < 1200) {
            if ("1" == vodi_options.enable_sticky_header && 0 < l("#page").find(".handheld-navbar-toggle-buttons").length) new Waypoint.Sticky({
                element: l(".handheld-navbar-toggle-buttons")[0],
                stuckClass: "stuck animated fadeInDown faster"
            });
            if ("1" == vodi_options.enable_hh_sticky_header && 0 < l("#page").find(".handheld-stick-this").length) new Waypoint.Sticky({
                element: l(".handheld-stick-this")[0],
                stuckClass: "stuck animated fadeInDown faster",
                offset: function () {
                    return -this.element.clientHeight
                }
            })
        }
    })
}(jQuery, window);
! function (a, b) {
    "use strict";

    function c() {
        if (!e) {
            e = !0;
            var a, c, d, f, g = -1 !== navigator.appVersion.indexOf("MSIE 10"),
                h = !!navigator.userAgent.match(/Trident.*rv:11\./),
                i = b.querySelectorAll("iframe.wp-embedded-content");
            for (c = 0; c < i.length; c++) {
                if (d = i[c], !d.getAttribute("data-secret")) f = Math.random().toString(36).substr(2, 10), d.src += "#?secret=" + f, d.setAttribute("data-secret", f);
                if (g || h) a = d.cloneNode(!0), a.removeAttribute("security"), d.parentNode.replaceChild(a, d)
            }
        }
    }
    var d = !1,
        e = !1;
    if (b.querySelector)
        if (a.addEventListener) d = !0;
    if (a.wp = a.wp || {}, !a.wp.receiveEmbedMessage)
        if (a.wp.receiveEmbedMessage = function (c) {
            var d = c.data;
            if (d)
                if (d.secret || d.message || d.value)
                    if (!/[^a-zA-Z0-9]/.test(d.secret)) {
                        var e, f, g, h, i, j = b.querySelectorAll('iframe[data-secret="' + d.secret + '"]'),
                            k = b.querySelectorAll('blockquote[data-secret="' + d.secret + '"]');
                        for (e = 0; e < k.length; e++) k[e].style.display = "none";
                        for (e = 0; e < j.length; e++)
                            if (f = j[e], c.source === f.contentWindow) {
                                if (f.removeAttribute("style"), "height" === d.message) {
                                    if (g = parseInt(d.value, 10), g > 1e3) g = 1e3;
                                    else if (~~g < 200) g = 200;
                                    f.height = g
                                }
                                if ("link" === d.message)
                                    if (h = b.createElement("a"), i = b.createElement("a"), h.href = f.getAttribute("src"), i.href = d.value, i.host === h.host)
                                        if (b.activeElement === f) a.top.location.href = d.value
                            }
                    }
        }, d) a.addEventListener("message", a.wp.receiveEmbedMessage, !1), b.addEventListener("DOMContentLoaded", c, !1), a.addEventListener("load", c, !1)
}(window, document)